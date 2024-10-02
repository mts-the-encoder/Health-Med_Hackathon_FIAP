using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class ApontamentoRepository : IApontamentoRepository
{
	private readonly HackathonDbContext _ctx;

	public ApontamentoRepository(HackathonDbContext ctx) 
	{
	}

	public async Task<Apontamento> Add(long medicoId, Apontamento apontamento)
	{
		await _ctx.AddAsync(apontamento);
		await _ctx.SaveChangesAsync();

		return apontamento;
	}

	public async Task AtualizaHorarioDisponivel(long medicoId, Apontamento apontamento)
	{
		_ctx.Update(apontamento);
		await _ctx.SaveChangesAsync();
	}
}