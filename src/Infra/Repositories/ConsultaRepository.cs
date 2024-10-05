using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ConsultaRepository : IConsultaRepository
{
	private readonly HackathonDbContext _ctx;
	private readonly IApontamentoRepository _apontamentoRepository;

	public ConsultaRepository(HackathonDbContext ctx, IApontamentoRepository apontamentoRepository)
	{
		_ctx = ctx;
		_apontamentoRepository = apontamentoRepository;
	}

	public async Task<Consulta> Add(Consulta consulta)
	{
		await _ctx.AddAsync(consulta);
		await _ctx.SaveChangesAsync();

		return await _ctx.Consultas
			.Include(c => c.Paciente)
			.Include(c => c.Medico)
			.Include(c => c.Apontamento)
			.FirstOrDefaultAsync(c => c.Id == consulta.Id);
	}

	public async Task<bool> ExistDisponibilidade(long medicoId, DayOfWeek day, TimeSpan horarioInicial, TimeSpan horarioFinal)
	{
		return await _apontamentoRepository
			.Disponibilidade(medicoId, day, horarioInicial, horarioFinal);
	}

	public async Task LoadPacienteAndMedico(Consulta consulta)
	{
		consulta.Paciente = await _ctx.Pacientes.FindAsync(consulta.PacienteId);
		consulta.Medico = await _ctx.Medicos.FindAsync(consulta.MedicoId);
		consulta.Apontamento = await _ctx.Apontamentos.FindAsync(consulta.ApontamentoId);
	}
}