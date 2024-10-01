using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
	public UsuarioRepository(HackathonDbContext ctx) : base(ctx)
	{
	}
}