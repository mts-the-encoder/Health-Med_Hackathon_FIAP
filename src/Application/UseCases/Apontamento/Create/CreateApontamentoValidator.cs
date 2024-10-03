using Communication.Requests;
using FluentValidation;

namespace Application.UseCases.Apontamento.Create;

public class CreateApontamentoValidator : AbstractValidator<CreateApontamentoRequest>
{
	public CreateApontamentoValidator()
	{
		RuleFor(x => x.HorarioInicial)
			.NotEmpty().WithMessage("O horário inicial deve ser informado.")
			.LessThan(x => x.HorarioFinal).WithMessage("O horário inicial deve ser anterior ao horário final.");

		RuleFor(x => x.HorarioFinal)
			.NotEmpty().WithMessage("O horário final deve ser informado.")
			.GreaterThan(x => x.HorarioInicial).WithMessage("O horário final deve ser posterior ao horário inicial.");

		RuleFor(x => x.Dia)
			.IsInEnum().WithMessage("O dia da semana deve ser um valor válido.");
	}
}