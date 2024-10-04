using Application.UseCases.Apontamento.Create;
using Application.UseCases.Atendimento.Create;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Consulta;

public class CreateConsultaValidatorTest
{
	[Fact]
	public void Success()
	{
		var validator = new CreateConsultaValidator();
		var request = ConsultaRequestBuilder.Build();

		var result = validator.Validate(request);

		result.IsValid.Should().BeTrue();
	}
}