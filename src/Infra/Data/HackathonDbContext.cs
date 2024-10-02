using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data;

public class HackathonDbContext : DbContext
{
	
	private readonly IConfiguration _configuration;

	public HackathonDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
	{
		_configuration = configuration;
	}

	public HackathonDbContext() : base() { }

	public HackathonDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public DbSet<Medico> Medicos { get; set; }
	public DbSet<Paciente> Pacientes { get; set; }
	public DbSet<Consulta> Consultas { get; set; }
	public DbSet<Apontamento> Apontamentos { get; set; }


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString = _configuration.GetConnectionString("DefaultConnection");
		optionsBuilder.UseSqlServer(connectionString);
		optionsBuilder.EnableSensitiveDataLogging();
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(HackathonDbContext).Assembly);
	}
}