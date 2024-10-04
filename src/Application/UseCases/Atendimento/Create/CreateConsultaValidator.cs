using Communication.Requests;
using FluentValidation;

namespace Application.UseCases.Atendimento.Create;

public class CreateConsultaValidator : AbstractValidator<ConsultaRequest>
{
	public CreateConsultaValidator()
	{
		RuleFor(x => x.MedicoId).NotEmpty().WithMessage("Médico deve ser informado");
		RuleFor(x => x.PacienteId).NotEmpty().WithMessage("Paciente deve ser informado");
		RuleFor(x => x.Atendimento)
			.GreaterThan(x => DateTime.Now).WithMessage("A data deve ser a partir de hoje")
			.NotEmpty().WithMessage("Deve ser informado o horário e dia da consulta");
	}
}