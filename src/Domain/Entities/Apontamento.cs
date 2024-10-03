using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Apontamento
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; } 
	public long MedicoId { get; set; }
	public TimeSpan HorarioInicial { get; set; }
	public TimeSpan HorarioFinal { get; set; }
	public DayOfWeek Dia { get; set; }
}