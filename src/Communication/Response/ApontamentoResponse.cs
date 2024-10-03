namespace Communication.Response;

public class ApontamentoResponse
{
	public long MedicoId { get; set; }
	public TimeSpan HorarioInicial { get; set; }
	public TimeSpan HorarioFinal { get; set; }
	public DayOfWeek Dia { get; set; }
}