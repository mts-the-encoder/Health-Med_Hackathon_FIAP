using Application.UseCases.Apontamento.Create;
using Application.UseCases.Apontamento.Update;
using Azure;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
public class ApontamentoController : HackathonController
{
	[HttpPost]
	[ProducesResponseType(typeof(ApontamentoResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> CreateAgenda([FromServices] ICreateApontamentoUseCase useCase, [FromBody] ApontamentoRequest request)
	{
		var response = await useCase.Execute(request);

		return Ok(response);
	}

	[HttpPut("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update([FromServices] IUpdateApontamentoUseCase useCase, [FromRoute] long id, [FromBody] ApontamentoRequest request)
	{
		await useCase.Execute(id, request);

		return Ok();
	}
}