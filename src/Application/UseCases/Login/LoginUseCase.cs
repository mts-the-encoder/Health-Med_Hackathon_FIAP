using Application.Tokens;
using Communication.Requests;
using Communication.Response;
using Domain.Repositories;
using Exception.ExceptionBase;

namespace Application.UseCases.Login;

public class LoginUseCase : ILoginUseCase
{
	private readonly IAccessTokenGenerator _accessTokenGenerator;
	private readonly IMedicoRepository _medicoRepository;
	private readonly IPacienteRepository _pacienteRepository;

	public LoginUseCase(IAccessTokenGenerator accessTokenGenerator, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository)
	{
		_accessTokenGenerator = accessTokenGenerator;
		_medicoRepository = medicoRepository;
		_pacienteRepository = pacienteRepository;
	}

	public async Task<LoginResponse> Execute(LoginRequest request)
	{
		var paciente = await _pacienteRepository.GetUserByEmail(request.Email);
		var medico = await _medicoRepository.GetUserByEmail(request.Email);

		if (paciente is not null)
		{
			return new LoginResponse()
			{
				Nome = paciente.Nome,
				Token = _accessTokenGenerator.Generate(paciente)
			};
		}

		if (medico is not null)
		{
			return new LoginResponse()
			{
				Nome = medico.Nome,
				Token = _accessTokenGenerator.Generate(medico)
			};
		}

		throw new InvalidLoginException("");
	}
}