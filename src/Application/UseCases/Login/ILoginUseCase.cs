using Communication.Requests;
using Communication.Response;

namespace Application.UseCases.Login;

public interface ILoginUseCase
{
	Task<LoginResponse> Execute(LoginRequest request);
}