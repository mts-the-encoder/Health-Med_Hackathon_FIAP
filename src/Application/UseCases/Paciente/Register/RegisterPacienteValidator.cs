using Communication.Requests;
using FluentValidation;

namespace Application.UseCases.Paciente.Register;

public class RegisterPacienteValidator : AbstractValidator<CreatePacienteRequest>
{
	public RegisterPacienteValidator()
	{
		RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome não pode ser vazio");
		RuleFor(x => x.CPF).IsValidCPF().WithMessage("CPF inválido");
		RuleFor(x => x.Senha).NotEmpty().MinimumLength(5).WithMessage("Senha inválida");
		RuleFor(user => user.Email)
			.NotEmpty()
			.WithMessage("Email não pode ser vazio")
			.EmailAddress()
			.When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
			.WithMessage("Email inválido");
	}
}