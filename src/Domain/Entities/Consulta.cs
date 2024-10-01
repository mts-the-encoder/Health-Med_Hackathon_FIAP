namespace Domain.Entities;

public class Consulta
{
	public long Id { get; set; }
	public long PacienteId { get; set; }
	public long MedicoId { get; set; }
	public DateTime Atendimento { get; set; }
}