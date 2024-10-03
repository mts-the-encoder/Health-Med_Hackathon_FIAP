using AutoMapper;
using Communication.Requests;
using Communication.Response;
using Domain.Repositories;
using Exception.ExceptionBase;
using FluentValidation.Results;

namespace Application.UseCases.Apontamento.Create;

public class CreateApontamentoUseCase : ICreateApontamentoUseCase
{
	private readonly IMapper _mapper;
	private readonly IApontamentoRepository _repository;

	public CreateApontamentoUseCase(IApontamentoRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ApontamentoResponse> Execute(CreateApontamentoRequest req)
	{
		await Validate(req);

		var apontamento = _mapper.Map<Domain.Entities.Apontamento>(req);

		await _repository.Add(apontamento);

		return _mapper.Map<ApontamentoResponse>(apontamento);
	}

	private async Task Validate(CreateApontamentoRequest request)
	{
		var result = await new CreateApontamentoValidator().ValidateAsync(request);

		var existDisponibilidade = await _repository.Disponibilidade(request.MedicoId, request.Dia, request.GetHorarioInicial(), request.GetHorarioFinal());

		if (existDisponibilidade)
			result.Errors.Add(new ValidationFailure(string.Empty, "Esse horário não está disponível"));

		if (result.IsValid == false)
		{
			var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errorMessages);
		}
	}
}