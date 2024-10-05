using System.Net;
using System.Net.Mail;

namespace Application.EmailSender;

public static class EmailService 
{
	public static void SendEmail(string medico, string paciente, DateTime dataConsulta, TimeSpan horario, string email)
	{
		var body = $"Olá, Dr. {medico}!\r\nVocê tem uma nova consulta marcada! Paciente: {paciente}." +
		           $"\r\nData e horário: {dataConsulta.Date} às {horario.Hours}h.";

		var client = new SmtpClient("live.smtp.mailtrap.io", 587)
		{
			Credentials = new NetworkCredential("api", "980d4ce762703754fae421077bc713b5"),
			EnableSsl = true
		};
		client.Send("hello@demomailtrap.com", email, "Hello world", body);
		Console.WriteLine("Sent");
	}
}
