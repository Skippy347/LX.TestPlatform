namespace LX.TestPlatform.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetAll();
    ValueTask DeleteAsync(T entity);
    ValueTask UpdateAsync(T entity);
}