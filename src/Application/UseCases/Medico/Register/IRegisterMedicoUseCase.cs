using Communication.Requests;
using Communication.Response;

namespace Application.UseCases.Medico.Register;

public interface IRegisterMedicoUseCase
{
	Task<MedicoResponse> Execute(CreateMedicoRequest req);
}