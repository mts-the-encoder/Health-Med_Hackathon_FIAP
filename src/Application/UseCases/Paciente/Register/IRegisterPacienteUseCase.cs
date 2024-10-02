using Communication.Requests;
using Communication.Response;

namespace Application.UseCases.Paciente.Register;

public interface IRegisterPacienteUseCase
{
	Task<PacienteResponse> Execute(CreatePacienteRequest req);
}