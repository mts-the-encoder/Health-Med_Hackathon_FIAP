using System.Net;

namespace Exception.ExceptionBase;

public class InvalidLoginException : HackathonException
{
	public InvalidLoginException(string message) : base(message)
	{
	}

	public override int StatusCode => (int)HttpStatusCode.Unauthorized;

	public override List<string> GetErrors()
	{
		return [Message];
	}
}