﻿namespace Communication.Requests;

public class CreatePacienteRequest
{
	public string Nome { get; set; }
	public string CPF { get; set; }
	public string Email { get; set; }
	public string Senha { get; set; }
}