using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class ApontamentoRepository : BaseRepository<Apontamento>, IApontamentoRepository
{
	public ApontamentoRepository(HackathonDbContext ctx) : base(ctx)
	{
	}
}