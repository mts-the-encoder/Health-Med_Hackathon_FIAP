using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class MedicoRepositoryBuilder
{
	private static MedicoRepositoryBuilder _instance;
	private readonly Mock<IMedicoRepository> _repository;

	private MedicoRepositoryBuilder()
	{
		_repository ??= new Mock<IMedicoRepository>();
	}

	public static MedicoRepositoryBuilder Instance()
	{
		_instance = new MedicoRepositoryBuilder();
		return _instance;
	}

	public IMedicoRepository Build()
	{
		return _repository.Object;
	}

	public MedicoRepositoryBuilder GetById(Medico medico)
	{
		if (!string.IsNullOrWhiteSpace(medico.Id.ToString()))
			_repository.Setup(i => i.GetUserByEmail(medico.Email)).ReturnsAsync(medico);

		return this;
	}

	public MedicoRepositoryBuilder Create(Medico medico)
	{
		_repository.Setup(x => x.Add(medico));

		return this;
	}
}