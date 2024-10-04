using Application.UseCases.Atendimento.Create;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ConsultaController : HackathonController
{
	[HttpPost]
	[ProducesResponseType(typeof(ConsultaResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromServices] ICreateConsultaUseCase useCase, [FromBody] ConsultaRequest request)
	{
		var response = await useCase.Execute(request);

		return Created(string.Empty, response);
	}
}