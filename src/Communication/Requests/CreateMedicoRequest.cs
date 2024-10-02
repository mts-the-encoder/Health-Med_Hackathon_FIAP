namespace Communication.Requests;

public class CreateMedicoRequest
{
	public string Nome { get; set; }
	public string CPF { get; set; }
	public string CRM { get; set; }
	public string Email { get; set; }
	public string Senha { get; set; }
}