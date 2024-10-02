using Domain.Entities;

namespace Domain.Repositories;

public interface IApontamentoRepository
{
	Task AtualizaHorarioDisponivel(long medicoId, Apontamento apontamento);
}