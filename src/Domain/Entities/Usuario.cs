﻿namespace Domain.Entities;

public class Usuario
{
	public long Id { get; set; }
	public string Nome { get; set; }
	public string CPF { get; set; }
	public string Email { get; set; }
	public string Senha { get; set; }
}