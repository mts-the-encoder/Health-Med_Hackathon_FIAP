using Application.Tokens;
using Domain.Entities;
using Moq;

namespace CommonTestUtilities.Token;

public class JwtTokenMedicoGeneratorBuilder
{
	public static IAccessTokenGenerator Build()
	{
		var mock = new Mock<IAccessTokenGenerator>();

		mock.Setup(accessTokenGenerator => accessTokenGenerator.Generate(It.IsAny<Medico>())).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");

		return mock.Object;
	}
}