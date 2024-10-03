using Application.UseCases.Apontamento.Create;
using Application.UseCases.Login;
using Azure;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ApontamentoController : HackathonController
{
	[HttpPost]
	[ProducesResponseType(typeof(ApontamentoResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> CreateAgenda([FromServices] ICreateApontamentoUseCase useCase, [FromBody] CreateApontamentoRequest request)
	{
		var response = await useCase.Execute(request);

		return Ok(response);
	}
}