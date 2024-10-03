using Application.Tokens;
using AutoMapper;
using Communication.Requests;
using Communication.Response;
using Domain.Repositories;
using Exception.ExceptionBase;
using FluentValidation.Results;

namespace Application.UseCases.Medico.Register;

public class RegisterMedicoUseCase : IRegisterMedicoUseCase
{
	private readonly IMapper _mapper;
	private readonly IMedicoRepository _repository;
	private readonly IAccessTokenGenerator _tokenGenerator;

	public RegisterMedicoUseCase(IMapper mapper, IMedicoRepository repository, IAccessTokenGenerator tokenGenerator)
	{
		_mapper = mapper;
		_repository = repository;
		_tokenGenerator = tokenGenerator;
	}

	public async Task<MedicoResponse> Execute(CreateMedicoRequest req)
	{
		await Validate(req);

		var medico = _mapper.Map<Domain.Entities.Medico>(req);

		await _repository.Add(medico);

		return new MedicoResponse
		{
			Nome = medico.Nome,
			CRM = medico.CRM,
			Token = _tokenGenerator.Generate(medico)
		};
	}

	private async Task Validate(CreateMedicoRequest request)
	{
		var result = await new RegisterMedicoValidator().ValidateAsync(request);

		var emailExist = await _repository.ExistActiveUserWithEmail(request.Email);

		if (emailExist)
			result.Errors.Add(new ValidationFailure(string.Empty, "Email já existe"));

		if (result.IsValid == false)
		{
			var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errorMessages);
		}
	}
}