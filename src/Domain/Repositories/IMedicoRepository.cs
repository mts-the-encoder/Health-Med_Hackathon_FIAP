using Domain.Entities;

namespace Domain.Repositories;

public interface IMedicoRepository
{
	Task<Medico> Login(string email, string senha);
	Task<bool> ExistActiveUserWithEmail(string requestEmail);
	Task<Medico> Add(Medico medico);
	Task<Medico> GetUserByEmail(string requestEmail);
}