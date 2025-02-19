using System.Linq.Expressions;
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

    Task<IQueryable<T>> GetPaginationAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeStringProperties = "",
        bool isTracking = false);
}
