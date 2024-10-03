using Application.Mapper;
using AutoMapper;

namespace CommonTestUtilities.Mapper;

public class MapperBuilder
{
	public static IMapper Build()
	{
		var mapper = new MapperConfiguration(config =>
		{
			config.AddProfile(new MapperConfig());
		});

		return mapper.CreateMapper();
	}
}