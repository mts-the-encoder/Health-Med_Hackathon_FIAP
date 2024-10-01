using Domain.Entities;

namespace Domain.Repositories;

public interface IMedicoRepository
{
	Task<Medico> Login(string email, string senha);
}