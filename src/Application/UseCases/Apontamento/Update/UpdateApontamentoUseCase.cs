using Application.UseCases.Apontamento.Create;
using AutoMapper;
using Communication.Requests;
using Domain.Repositories;
using Exception.ExceptionBase;

namespace Application.UseCases.Apontamento.Update;


public class UpdateApontamentoUseCase : IUpdateApontamentoUseCase
{
	private readonly IApontamentoRepository _repository;
	private readonly IMapper _mapper;

	public UpdateApontamentoUseCase(IApontamentoRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Execute(long id, ApontamentoRequest request)
	{
		Validate(request);

		var apontamento = await _repository.GetById(id);

		if (apontamento is null)
			throw new NotFoundException("Apontamento não encontrado");

		_mapper.Map(request, apontamento);

		await _repository.Update(apontamento);
	}

	private void Validate(ApontamentoRequest request)
	{
		var validator = new CreateApontamentoValidator();

		var result = validator.Validate(request);

		if (result.IsValid == false)
		{
			var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errorMessages);
		}
	}
}