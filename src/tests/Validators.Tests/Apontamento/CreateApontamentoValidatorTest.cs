﻿using Application.UseCases.Apontamento.Create;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Apontamento;

public class CreateApontamentoValidatorTest
{
	[Fact]
	public void Success()
	{
		var validator = new CreateApontamentoValidator();
		var request = ApontamentoRequestBuilder.Build();

		var result = validator.Validate(request);

		result.IsValid.Should().BeTrue();
	}

	[Theory]
	[InlineData("")]
	[InlineData("      ")]
	[InlineData(null)]
	public void Error_HorarioInicial_Empty(string horarioInicial)
	{
		var validator = new CreateApontamentoValidator();
		var request = ApontamentoRequestBuilder.Build();
		request.HorarioInicial = horarioInicial;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
	}


	[Theory]
	[InlineData("")]
	[InlineData("      ")]
	[InlineData(null)]
	public void Error_HorarioFinal_Empty(string horarioFinal)
	{
		var validator = new CreateApontamentoValidator();
		var request = ApontamentoRequestBuilder.Build();
		request.HorarioFinal = horarioFinal;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
		
	}

	[Fact]
	public void Error_HorarioFinal_Menor_Que_Final_Empty()
	{
		var validator = new CreateApontamentoValidator();
		var request = ApontamentoRequestBuilder.Build();

		var horarioInicial = TimeSpan.Parse(request.HorarioInicial).Add(TimeSpan.FromDays(8));
		var horarioFinal = TimeSpan.Parse(request.HorarioFinal);

		var result = validator.Validate(request);

		horarioInicial.Should().BeGreaterThan(horarioFinal);
		result.IsValid.Should().BeFalse();
	}

	[Fact]
	public void Error_Dia_Empty()
	{
		var validator = new CreateApontamentoValidator();
		var request = ApontamentoRequestBuilder.Build();
		request.Dia = (DayOfWeek)10;

		var result = validator.Validate(request);

		result.IsValid.Should().BeFalse();
	}
}