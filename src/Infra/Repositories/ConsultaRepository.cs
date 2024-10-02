using Domain.Entities;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories;

public class ConsultaRepository : IConsultaRepository
{
	public ConsultaRepository(HackathonDbContext ctx) 
	{
	}
}