using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
{
	public MedicoRepository(HackathonDbContext ctx) : base(ctx)
	{
	}
}