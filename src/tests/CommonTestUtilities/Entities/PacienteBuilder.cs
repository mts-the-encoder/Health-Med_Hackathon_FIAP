using Bogus;
using Bogus.Extensions.Brazil;
using Domain.Entities;

namespace CommonTestUtilities.Entities;

public class PacienteBuilder
{
	public static Paciente Build()
	{
		var paciente = new Faker<Paciente>()
			.RuleFor(x => x.Id, _ => 1)
			.RuleFor(x => x.Nome, f => f.Person.FirstName)
			.RuleFor(x => x.CPF, f => f.Person.Cpf())
			.RuleFor(x => x.Email, (f, paciente) => f.Internet.Email(paciente.Nome))
			.RuleFor(x => x.Senha, f => f.Internet.Password());

		return paciente;
	}
}