using Communication.Response;
using Exception;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if (context.Exception is HackathonException)
		{
			HandleProjectException(context);
		}
		else
		{
			ThrowUnkowError(context);
		}
	}

	private void HandleProjectException(ExceptionContext context)
	{
		var cashFlowException = (HackathonException)context.Exception;
		var errorResponse = new ErrorResponse(cashFlowException.GetErrors());

		context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
		context.Result = new ObjectResult(errorResponse);
	}

	private void ThrowUnkowError(ExceptionContext context)
	{
		var errorResponse = new ErrorResponse("Erro desconhecido");

		context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Result = new ObjectResult(errorResponse);
	}
}