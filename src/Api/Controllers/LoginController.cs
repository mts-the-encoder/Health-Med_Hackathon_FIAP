using Application.UseCases.Login;
using Azure;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class LoginController : HackathonController
{
	[HttpPost]
	[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> Login([FromServices] ILoginUseCase useCase, [FromBody] LoginRequest request)
	{
		var response = await useCase.Execute(request);

		return Ok(response);
	}
}