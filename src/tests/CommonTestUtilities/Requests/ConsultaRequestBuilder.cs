using Bogus;
using Communication.Requests;

namespace CommonTestUtilities.Requests;

public class ConsultaRequestBuilder
{
	public static ConsultaRequest Build()
	{
		return new Faker<ConsultaRequest>()
			.RuleFor(x => x.MedicoId, _ => 1)
			.RuleFor(x => x.PacienteId, _ => 1)
			.RuleFor(x => x.Atendimento, f => f.Date.Soon());
	}
}