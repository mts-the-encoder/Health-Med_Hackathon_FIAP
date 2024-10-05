namespace Communication.Requests;

public class ConsultaRequest
{
	public long PacienteId { get; set; }
	public long MedicoId { get; set; }
	public long ApontamentoId { get; set; }
	public DateTime Atendimento { get; set; }
}