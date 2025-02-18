using ProductsApp.Domain.Common;

namespace ProductsApp.Domain.Ports;
public interface IRepository<T> where T : DomainEntity
{
    Task<T> GetOneAsync(Guid id, string? includeStringProperties = default);
    Task<IEnumerable<T>> GetManyAsync(
        string includeStringProperties = "",
        bool isTracking = false);
    Task<T> AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
}
