using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Consulta
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	public long PacienteId { get; set; }
	public long MedicoId { get; set; }
	public DateTime Atendimento { get; set; }
	public virtual Paciente Paciente { get; set; }
	public virtual Medico Medico { get; set; }
}