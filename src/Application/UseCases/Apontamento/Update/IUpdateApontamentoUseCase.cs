using Communication.Requests;

namespace Application.UseCases.Apontamento.Update;

public interface IUpdateApontamentoUseCase
{
	Task Execute(long id, ApontamentoRequest request);
}