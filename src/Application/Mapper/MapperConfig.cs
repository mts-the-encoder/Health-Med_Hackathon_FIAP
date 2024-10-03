using AutoMapper;
using Communication.Requests;
using Communication.Response;
using Domain.Entities;

namespace Application.Mapper;

public class MapperConfig : Profile
{
	public MapperConfig()
	{
		RequestToEntity();
		EntityToResponse();
	}

	private void RequestToEntity()
	{
		CreateMap<CreatePacienteRequest, Paciente>();
		CreateMap<CreateMedicoRequest, Medico>();
	}

    private void EntityToResponse()
    {
        CreateMap<Paciente, PacienteResponse>();
        CreateMap<Medico, MedicoResponse>();
        CreateMap<Medico, MedicosResponse>();
	}
}