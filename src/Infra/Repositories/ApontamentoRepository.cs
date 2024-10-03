using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ApontamentoRepository : IApontamentoRepository
{
	private readonly HackathonDbContext _ctx;

	public ApontamentoRepository(HackathonDbContext ctx)
	{
		_ctx = ctx;
	}

	public async Task<Apontamento> Add(Apontamento apontamento)
	{
		await _ctx.Apontamentos.AddAsync(apontamento);
		await _ctx.SaveChangesAsync();

		return apontamento;
	}

	public async Task AtualizaHorarioDisponivel(Apontamento apontamento)
	{
		_ctx.Apontamentos.Update(apontamento);
		await _ctx.SaveChangesAsync();
	}

	public async Task<Apontamento> GetById(long id)
	{
		return await _ctx.Apontamentos
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task Update(Apontamento apontamento)
	{
		_ctx.Apontamentos.Update(apontamento);
		await _ctx.SaveChangesAsync();
	}

	public async Task<bool> Disponibilidade(long medicoId, DayOfWeek dia, TimeSpan horarioInicial, TimeSpan horarioFinal)
	{
		return await _ctx.Apontamentos.AnyAsync(d =>
			d.MedicoId == medicoId &&
			d.Dia == dia &&
			d.HorarioInicial < horarioFinal && 
			d.HorarioFinal > horarioInicial);
	}
}