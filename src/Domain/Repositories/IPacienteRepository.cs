using Domain.Entities;

namespace Domain.Repositories;

public interface IPacienteRepository
{
	Task<Paciente> Login(string email, string senha);
	Task<IEnumerable<Medico>> GetAllMedicosAsync();
}