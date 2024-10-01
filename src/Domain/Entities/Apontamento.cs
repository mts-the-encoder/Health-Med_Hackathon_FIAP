namespace Domain.Entities;

public class Apontamento
{
	public long Id { get; set; }
	public long MedicoId { get; set; }
	public TimeSpan HorarioInicial { get; set; }
	public TimeSpan HorarioFinal { get; set; }
	public DayOfWeek Dia { get; set; }
	public virtual Medico Medico { get; set; }
}