using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
{
	public PacienteRepository(HackathonDbContext ctx) : base(ctx)
	{
	}
}