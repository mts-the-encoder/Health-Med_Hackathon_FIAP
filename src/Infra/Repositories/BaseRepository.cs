using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
	protected readonly HackathonDbContext _ctx;
	protected readonly DbSet<T> _dbSet;

	public BaseRepository(HackathonDbContext ctx)
	{
		_ctx = ctx;
		_dbSet = _ctx.Set<T>();
	}

	public async Task Add(T entity)
	{
		await _dbSet.AddAsync(entity);
		await _ctx.SaveChangesAsync();
	}
}

