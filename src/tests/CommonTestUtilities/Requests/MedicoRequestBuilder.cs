using Bogus;
using Bogus.Extensions.Brazil;
using Communication.Requests;

namespace CommonTestUtilities.Requests;

public class MedicoRequestBuilder
{
	public static CreateMedicoRequest Build()
	{
		return new Faker<CreateMedicoRequest>()
			.RuleFor(x => x.Nome, f => f.Person.FullName)
			.RuleFor(x => x.Email, f => f.Internet.Email())
			.RuleFor(x => x.CPF, f => f.Person.Cpf())
			.RuleFor(x => x.CRM, _ => "123456-SP")
			.RuleFor(x => x.Senha, f => f.Internet.Password());
	}
}