namespace Communication.Response;

public class ConsultaResponse
{
	public long PacienteId { get; set; }
	public long MedicoId { get; set; }
	public DateTime Atendimento { get; set; }
	public PacienteResponse Paciente { get; set; }
	public MedicoResponse Medico { get; set; }
}