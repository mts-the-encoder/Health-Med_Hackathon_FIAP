using Bogus;
using Communication.Requests;

namespace CommonTestUtilities.Requests;

public class ApontamentoRequestBuilder
{
	public static ApontamentoRequest Build()
	{
		return new Faker<ApontamentoRequest>()
			.RuleFor(x => x.MedicoId, _ => 1)
			.RuleFor(x => x.Dia, _ => DayOfWeek.Friday)
			.RuleFor(x => x.HorarioInicial, f => f.Date.Timespan().ToString())
			.RuleFor(x => x.HorarioFinal, f => f.Date.Timespan().ToString());
	}
}