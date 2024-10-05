using Application.UseCases.Paciente.GetAll;
using Application.UseCases.Paciente.Register;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
public class PacienteController : HackathonController
{
	[AllowAnonymous]
	[HttpPost]
	[ProducesResponseType(typeof(PacienteResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromServices] IRegisterPacienteUseCase useCase, [FromBody] CreatePacienteRequest request)
	{
		var response = await useCase.Execute(request);

		return Created(string.Empty, response);
	}

	[HttpGet("getAllMedicos")]
	[ProducesResponseType(typeof(IEnumerable<MedicosResponse>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> GetMedicos ([FromServices] IGetAllMedicosUseCase useCase)
	{
		var response = await useCase.Execute();

		return Ok(response);
	}
}