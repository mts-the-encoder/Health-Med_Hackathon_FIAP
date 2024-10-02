namespace Exception;

public abstract class HackathonException : SystemException
{
	protected HackathonException(string message) : base(message)
	{
	}

	public abstract int StatusCode { get; }
	public abstract List<string> GetErrors();
}