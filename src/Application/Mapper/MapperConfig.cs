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
	}

    private void EntityToResponse()
    {
        CreateMap<Paciente, PacienteResponse>();
    }
}