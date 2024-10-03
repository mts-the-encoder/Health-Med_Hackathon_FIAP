using Bogus;
using Domain.Entities;

namespace CommonTestUtilities.Entities;

public class ApontamentoBuilder
{
	public Apontamento Build()
	{
		var apontamento = new Faker<Apontamento>()
			.RuleFor(x => x.Id, _ => 1)
			.RuleFor(x => x.Dia, _ => DayOfWeek.Monday)
			.RuleFor(x => x.HorarioInicial, f => f.Date.Timespan())
			.RuleFor(x => x.HorarioFinal, f => f.Date.Timespan())
			.RuleFor(x => x.MedicoId, _ => 1);

		return apontamento;
	}
}