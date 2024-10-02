using Application.UseCases.Paciente.Register;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class PacienteController : HackathonController
{
	[HttpPost]
	[ProducesResponseType(typeof(PacienteResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromServices] IRegisterPacienteUseCase useCase, [FromBody] CreatePacienteRequest request)
	{
		var response = await useCase.Execute(request);

		return Created(string.Empty, response);
	}

}