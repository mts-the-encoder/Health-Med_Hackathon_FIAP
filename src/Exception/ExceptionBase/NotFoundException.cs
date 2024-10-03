using System.Net;

namespace Exception.ExceptionBase;

public class NotFoundException : HackathonException
{
	public NotFoundException(string message) : base(message)
	{
	}

	public override int StatusCode => (int)HttpStatusCode.NotFound;

	public override List<string> GetErrors()
	{
		return [Message];
	}
}