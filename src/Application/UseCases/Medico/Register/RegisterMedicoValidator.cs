using Communication.Requests;
using FluentValidation;

namespace Application.UseCases.Medico.Register;

public class RegisterMedicoValidator : AbstractValidator<CreateMedicoRequest>
{
	public RegisterMedicoValidator()
	{
		RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome não pode ser vazio");
		RuleFor(x => x.CPF).IsValidCPF().WithMessage("CPF inválido");
		RuleFor(x => x.CRM).Matches(@"^\d{6,7}-[A-Z]{2}$")
			.WithMessage("O CRM deve estar no formato correto, como '123456-SP'.");
		RuleFor(x => x.Senha).NotEmpty().MinimumLength(5).WithMessage("Senha inválida");
		RuleFor(user => user.Email)
			.NotEmpty()
			.WithMessage("Email não pode ser vazio")
			.EmailAddress()
			.When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
			.WithMessage("Email inválido");
	}
}