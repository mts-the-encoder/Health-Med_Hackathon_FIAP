using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PacienteRepository : IPacienteRepository
{
	private readonly HackathonDbContext _ctx;

	public PacienteRepository(HackathonDbContext ctx)
	{
		_ctx = ctx;
	}

	public async Task<Paciente> Add(Paciente paciente)
	{
		await _ctx.AddAsync(paciente);
		await _ctx.SaveChangesAsync();

		return paciente;
	}

	public async Task<Paciente> GetUserByEmail(string requestEmail)
	{
		return await _ctx.Pacientes.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(requestEmail));
	}

	public async Task<Paciente> Login(string email, string senha)
	{
		return await _ctx.Pacientes
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Senha.Equals(senha));
	}

	public async Task<IEnumerable<Medico>> GetAllMedicosAsync()
	{
		return await _ctx.Medicos
			.AsNoTracking()
			.ToListAsync();
	}

	public Task<bool> ExistActiveUserWithEmail(string requestEmail)
	{
		return _ctx.Pacientes.AnyAsync(user => user.Email.Equals(requestEmail));
	}
}