using Communication.Requests;
using Communication.Response;

namespace Application.UseCases.Atendimento.Create;

public interface ICreateConsultaUseCase
{
	Task<ConsultaResponse> Execute(ConsultaRequest req);
}