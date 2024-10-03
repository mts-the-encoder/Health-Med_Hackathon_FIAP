namespace Communication.Requests;

public class ApontamentoRequest
{
	public long MedicoId { get; set; }
	public string HorarioInicial { get; set; } 
	public string HorarioFinal { get; set; }
	public DayOfWeek Dia { get; set; }

	public TimeSpan GetHorarioInicial() => TruncateMilliseconds(TimeSpan.Parse(HorarioInicial));
	public TimeSpan GetHorarioFinal() => TruncateMilliseconds(TimeSpan.Parse(HorarioFinal));

	private TimeSpan TruncateMilliseconds(TimeSpan timeSpan)
	{
		return new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
	}
}