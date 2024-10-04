using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

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

		return consulta;
	}

	public async Task<bool> ExistDisponibilidade(long medicoId, DayOfWeek day, TimeSpan horarioInicial, TimeSpan horarioFinal)
	{
		return await _apontamentoRepository
			.Disponibilidade(medicoId, day, horarioInicial, horarioFinal);
	}
}