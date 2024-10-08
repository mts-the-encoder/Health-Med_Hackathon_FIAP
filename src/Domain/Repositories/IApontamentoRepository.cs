﻿using Domain.Entities;

namespace Domain.Repositories;

public interface IApontamentoRepository
{
	Task<Apontamento> Add(Apontamento apontamento);
	Task AtualizaHorarioDisponivel(Apontamento apontamento);
	Task<Apontamento> GetById(long id);
	Task Update(Apontamento apontamento);
	Task<bool> Disponibilidade(long medicoId, DayOfWeek dia, TimeSpan horarioInicial, TimeSpan horarioFinal);
}