using AutoMapper;
using Communication.Requests;
using Communication.Response;
using Domain.Repositories;
using Exception.ExceptionBase;
using FluentValidation.Results;

namespace Application.UseCases.Paciente.Register;

public class RegisterPacienteUseCase : IRegisterPacienteUseCase
{
	private readonly IMapper _mapper;
	private readonly IPacienteRepository _repository;

	public RegisterPacienteUseCase(IMapper mapper, IPacienteRepository repository)
	{
		_mapper = mapper;
		_repository = repository;	
	}

	public async Task<PacienteResponse> Execute(CreatePacienteRequest req)
	{
		await Validate(req);

		var paciente = _mapper.Map<Domain.Entities.Paciente>(req);

		await _repository.Add(paciente);

		return new PacienteResponse
		{
			Nome = paciente.Nome,
			//Token = _tokenGenerator.Generate(user)
		};
	}

	private async Task Validate(CreatePacienteRequest request)
	{
		var result = await new RegisterPacienteValidator().ValidateAsync(request);

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