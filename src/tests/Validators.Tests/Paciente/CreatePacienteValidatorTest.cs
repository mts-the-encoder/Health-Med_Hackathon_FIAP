using Application.UseCases.Paciente.Register;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Paciente;

public class CreatePacienteValidatorTest
{
	[Fact]
	public void Success()
	{
		//Arrange
		var validator = new RegisterPacienteValidator();
		var request = PacienteRequestBuilder.Build();

		//Act
		var result = validator.Validate(request);

		//Assert
		result.IsValid.Should().BeTrue();
	}

	[Theory]
	[InlineData("")]
	[InlineData("      ")]
	[InlineData(null)]
	public void Error_Name_Empty(string name)
	{
		var validator = new RegisterPacienteValidator();
		var request = PacienteRequestBuilder.Build();
		request.Nome = name;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should()
			.ContainSingle()
				.And
			.Contain(e => e.ErrorMessage.Equals("Nome não pode ser vazio"));
	}

	[Theory]
	[InlineData("")]
	[InlineData("      ")]
	[InlineData(null)]
	public void Error_Email_Empty(string email)
	{
		var validator = new RegisterPacienteValidator();
		var request = PacienteRequestBuilder.Build();
		request.Email = email;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should()
			.ContainSingle()
				.And
			.Contain(e => e.ErrorMessage.Equals("Email não pode ser vazio"));
	}

	[Fact]
	public void Error_Email_Invalid()
	{
		var validator = new RegisterPacienteValidator();
		var request = PacienteRequestBuilder.Build();
		request.Email = "welisson.com";

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		result.Errors.Should()
			.ContainSingle()
				.And
			.Contain(e => e.ErrorMessage.Equals("Email inválido"));
	}

	[Fact]
	public void Error_Password_Empty()
	{
		var validator = new RegisterPacienteValidator();
		var request = PacienteRequestBuilder.Build();
		request.Senha = string.Empty;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
	}
}