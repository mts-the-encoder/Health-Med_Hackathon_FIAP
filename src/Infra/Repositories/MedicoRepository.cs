using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class MedicoRepository : IMedicoRepository
{
	private readonly HackathonDbContext _ctx;

	public MedicoRepository(HackathonDbContext ctx)
	{
		_ctx = ctx;
	}

	public async Task<Medico> Add(Medico medico)
	{
		await _ctx.AddAsync(medico);
		await _ctx.SaveChangesAsync();

		return medico;
	}

	public async Task<Medico> GetUserByEmail(string requestEmail)
	{
		return await _ctx.Medicos.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(requestEmail));
	}

	public async Task<Medico> Login(string email, string senha)
	{
		return await _ctx.Medicos
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Senha.Equals(senha));
	}

	public async Task<bool> ExistActiveUserWithEmail(string requestEmail)
	{
		return await _ctx.Medicos.AnyAsync(user => user.Email.Equals(requestEmail));
	}
}