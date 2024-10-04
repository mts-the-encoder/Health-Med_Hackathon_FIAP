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

	[Theory]
	[InlineData(null)]
	public void Error_MedicoId_Empty(long medicoId)
	{
		var validator = new CreateConsultaValidator();
		var request = ConsultaRequestBuilder.Build();
		request.MedicoId = medicoId;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should().ContainSingle();
	}

	[Theory]
	[InlineData(null)]
	public void Error_PacienteId_Empty(long pacienteId)
	{
		var validator = new CreateConsultaValidator();
		var request = ConsultaRequestBuilder.Build();
		request.PacienteId = pacienteId;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should().ContainSingle();
	}
}