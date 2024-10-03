using Bogus;
using Domain.Entities;

namespace CommonTestUtilities.Entities;

public class ConsultaBuilder
{
	public Consulta Build()
	{
		var consulta = new Faker<Consulta>()
			.RuleFor(x => x.Id, _ => 1)
			.RuleFor(x => x.MedicoId, _ => 1)
			.RuleFor(x => x.PacienteId, _ => 1)
			.RuleFor(x => x.Paciente, _ => PacienteBuilder.Build())
			.RuleFor(x => x.Medico, _ => MedicoBuilder.Build());

		return consulta;
	}
}