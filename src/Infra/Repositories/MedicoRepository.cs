using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
{
	public MedicoRepository(HackathonDbContext ctx) : base(ctx)
	{
	}

	public async Task<Medico> Login(string email, string senha)
	{
		return await _ctx.Medicos
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Senha.Equals(senha));
	}
}