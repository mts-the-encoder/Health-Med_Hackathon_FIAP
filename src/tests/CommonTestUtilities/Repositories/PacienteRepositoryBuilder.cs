using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class PacienteRepositoryBuilder
{
	private static PacienteRepositoryBuilder _instance;
	private readonly Mock<IPacienteRepository> _repository;

	public PacienteRepositoryBuilder()
	{
		_repository ??= new Mock<IPacienteRepository>();
	}

	public static PacienteRepositoryBuilder Instance()
	{
		_instance = new PacienteRepositoryBuilder();
		return _instance;
	}

	public IPacienteRepository Build()
	{
		return _repository.Object;
	}

	public PacienteRepositoryBuilder GetById(Paciente paciente)
	{
		if (!string.IsNullOrWhiteSpace(paciente.Id.ToString()))
			_repository.Setup(i => i.GetUserByEmail(paciente.Email)).ReturnsAsync(paciente);

		return this;
	}

	public PacienteRepositoryBuilder GetUserByEmail(Paciente paciente)
	{
		if (!string.IsNullOrWhiteSpace(paciente.Id.ToString()))
			_repository.Setup(i => i.GetUserByEmail(paciente.Email)).ReturnsAsync(paciente);

		return this;
	}

	public PacienteRepositoryBuilder GetById(IEnumerable<Medico> medicos)
	{
		_repository.Setup(i => i.GetAllMedicosAsync()).ReturnsAsync(medicos);

		return this;
	}

	public PacienteRepositoryBuilder Create(Paciente paciente)
	{
		_repository.Setup(x => x.Add(paciente));

		return this;
	}
}