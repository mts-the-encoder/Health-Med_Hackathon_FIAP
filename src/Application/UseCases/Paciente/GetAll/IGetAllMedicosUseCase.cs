using Communication.Response;

namespace Application.UseCases.Paciente.GetAll;

public interface IGetAllMedicosUseCase
{
	Task<IEnumerable<MedicosResponse>> Execute();
}