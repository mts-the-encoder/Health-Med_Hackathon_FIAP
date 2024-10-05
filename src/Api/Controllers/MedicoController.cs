using Application.UseCases.Medico.Register;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class MedicoController : HackathonController
{
	[HttpPost]
	[ProducesResponseType(typeof(MedicoResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromServices] IRegisterMedicoUseCase useCase, [FromBody] CreateMedicoRequest request)
	{
		var response = await useCase.Execute(request);

		return Created(string.Empty, response);
	}
}