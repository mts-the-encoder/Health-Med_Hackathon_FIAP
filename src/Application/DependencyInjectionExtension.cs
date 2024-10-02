using Application.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjectionExtension
{
	public static void AddApplication(this IServiceCollection services)
	{
		AddAutoMapper(services);
		AddUseCases(services);
	}

	private static void AddAutoMapper(IServiceCollection services)
	{
		services.AddAutoMapper(typeof(MapperConfig));
	}

	private static void AddUseCases(IServiceCollection services)
	{
		var types = Assembly.GetExecutingAssembly().GetTypes()
			.Where(x => x.GetInterfaces().Any(i => i.Name.EndsWith("UseCase")));

		foreach (var type in types)
		{
			var interfaces = type.GetInterfaces();
			foreach (var inter in interfaces)
				services.AddScoped(inter, type);
		}
	}
}