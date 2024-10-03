using AutoMapper;
using Communication.Response;
using Domain.Repositories;

namespace Application.UseCases.Paciente.GetAll;

public class GetAllMedicosUseCase : IGetAllMedicosUseCase
{
	private readonly IMapper _mapper;
	private readonly IPacienteRepository _repository;

	public GetAllMedicosUseCase(IPacienteRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<MedicosResponse>> Execute()
	{
		var medicos = await _repository.GetAllMedicosAsync();

		var response = _mapper.Map<IEnumerable<MedicosResponse>>(medicos);

		return response;
	}
}