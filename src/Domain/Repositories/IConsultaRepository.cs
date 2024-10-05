using System.Diagnostics.Tracing;
using Domain.Entities;

namespace Domain.Repositories;

public interface IConsultaRepository
{
	Task<Consulta> Add(Consulta consulta);
	Task<bool> ExistDisponibilidade(long medicoId, DayOfWeek day, TimeSpan horarioInicial, TimeSpan horarioFinal);
	Task LoadPacienteAndMedico(Consulta consulta);
}