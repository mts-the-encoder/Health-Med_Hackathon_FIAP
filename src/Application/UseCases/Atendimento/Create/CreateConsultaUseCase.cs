using Application.EmailSender;
using AutoMapper;
using Communication.Requests;
using Communication.Response;
using Domain.Entities;
using Domain.Repositories;
using Exception.ExceptionBase;
using FluentValidation.Results;

namespace Application.UseCases.Atendimento.Create;

public class CreateConsultaUseCase : ICreateConsultaUseCase
{
	private readonly IMapper _mapper;
	private readonly IConsultaRepository _repository;

	public CreateConsultaUseCase(IConsultaRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ConsultaResponse> Execute(ConsultaRequest req)
	{
		await Validate(req);

		var consulta = _mapper.Map<Consulta>(req);

		await _repository.Add(consulta);

		await _repository.LoadPacienteAndMedico(consulta);

		var response = new ConsultaResponse
		{
			PacienteId = consulta.PacienteId,
			MedicoId = consulta.MedicoId,
			ApontamentoId = consulta.ApontamentoId,
			Atendimento = consulta.Atendimento,
			Apontamento = _mapper.Map<ApontamentoResponse>(consulta.Apontamento), 
			Paciente = _mapper.Map<PacienteResponse>(consulta.Paciente),
			Medico = _mapper.Map<MedicoResponse>(consulta.Medico)
		};

		EmailService.SendEmail(response.Medico.Nome, response.Paciente.Nome, response.Atendimento, response.Apontamento.HorarioInicial, consulta.Medico.Email);

		return response;
	}

	private async Task Validate(ConsultaRequest request)
	{
		var result = await new CreateConsultaValidator().ValidateAsync(request);

		var emailExist = await _repository
			.ExistDisponibilidade(request.MedicoId, request.Atendimento.DayOfWeek, request.Atendimento.TimeOfDay, request.Atendimento.TimeOfDay.Add(new TimeSpan(1, 0, 0)));

		if (emailExist)
			result.Errors.Add(new ValidationFailure(string.Empty, "Email já existe"));

		if (result.IsValid == false)
		{
			var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errorMessages);
		}
	}
}