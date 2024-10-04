using Bogus;
using Communication.Requests;

namespace CommonTestUtilities.Requests;

public class LoginRequestBuilder
{
	public static LoginRequest Build()
	{
		return new Faker<LoginRequest>()
			.RuleFor(x => x.Email, f => f.Internet.Email())
			.RuleFor(x => x.Senha, f => f.Internet.Password());
	}
}