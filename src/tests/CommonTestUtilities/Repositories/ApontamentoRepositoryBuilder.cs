using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class ApontamentoRepositoryBuilder
{
	private static ApontamentoRepositoryBuilder _instance;
	private readonly Mock<IApontamentoRepository> _repository;

	private ApontamentoRepositoryBuilder()
	{
		_repository ??= new Mock<IApontamentoRepository>();
	}

	public static ApontamentoRepositoryBuilder Instance()
	{
		_instance = new ApontamentoRepositoryBuilder();
		return _instance;
	}

	public IApontamentoRepository Build()
	{
		return _repository.Object;
	}

	public ApontamentoRepositoryBuilder GetById(Apontamento apontamento)
	{
		if (!string.IsNullOrWhiteSpace(apontamento.Id.ToString()))
			_repository.Setup(i => i.GetById(apontamento.Id)).ReturnsAsync(apontamento);

		return this;
	}

	public ApontamentoRepositoryBuilder Create(Apontamento apontamento)
	{
		_repository.Setup(x => x.Add(apontamento));

		return this;
	}
}