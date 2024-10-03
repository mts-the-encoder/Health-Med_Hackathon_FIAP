using System.Reflection.Metadata.Ecma335;
using Bogus;
using Bogus.Extensions.Brazil;
using Communication.Requests;

namespace CommonTestUtilities.Requests;

public class PacienteRequestBuilder
{
	public static CreatePacienteRequest Build()
	{
		return new Faker<CreatePacienteRequest>()
			.RuleFor(x => x.Nome, f => f.Person.FullName)
			.RuleFor(x => x.Email, f => f.Internet.Email())
			.RuleFor(x => x.CPF, f => f.Person.Cpf())
			.RuleFor(x => x.Senha, f => f.Internet.Password());
	}
}