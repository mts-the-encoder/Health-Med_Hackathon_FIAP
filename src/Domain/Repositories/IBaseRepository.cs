namespace Domain.Repositories;

public interface IBaseRepository<in T>
{
	Task Add(T entity);
}