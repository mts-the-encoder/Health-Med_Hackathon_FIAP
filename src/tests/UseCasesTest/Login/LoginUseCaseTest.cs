using Application.UseCases.Login;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Domain.Entities;
using Exception.ExceptionBase;
using FluentAssertions;

namespace UseCasesTest.Login;

public class LoginUseCaseTest
{
	[Fact]
	public async Task Success_Paciente()
	{
		var paciente = PacienteBuilder.Build();

		var request = LoginRequestBuilder.Build();
		request.Email = paciente.Email;

		var useCase = CreateUseCase(paciente);

		var result = await useCase.Execute(request);

		result.Should().NotBeNull();
		result.Nome.Should().Be(paciente.Nome);
		//result.Token.Should().NotBeNullOrWhiteSpace();
	}

	[Fact]
	public async Task Error_Paciente_Not_Found()
	{
		var paciente = PacienteBuilder.Build();

		var request = LoginRequestBuilder.Build();

		var useCase = CreateUseCase(paciente);

		var act = async () => await useCase.Execute(request);

		var result = await act.Should().ThrowAsync<InvalidLoginException>();

		result.Where(ex => ex.GetErrors().Count == 1);
	}

	private LoginUseCase CreateUseCase(Paciente paciente)
	{
		var tokenGenerator = JwtTokenMedicoGeneratorBuilder.Build();
		var pacienteRepository = new PacienteRepositoryBuilder().GetUserByEmail(paciente).Build();
		var medicoRepository = new MedicoRepositoryBuilder().Build();

		return new LoginUseCase(tokenGenerator, medicoRepository, pacienteRepository);
	}
}