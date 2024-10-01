using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
{
	public PacienteRepository(HackathonDbContext ctx) : base(ctx)
	{
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
}