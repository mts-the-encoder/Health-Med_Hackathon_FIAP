using Communication.Requests;
using Communication.Response;

namespace Application.UseCases.Apontamento.Create;

public interface ICreateApontamentoUseCase
{
	Task<ApontamentoResponse> Execute(CreateApontamentoRequest req);
}