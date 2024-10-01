using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
{
	public ConsultaRepository(HackathonDbContext ctx) : base(ctx)
	{
	}
}