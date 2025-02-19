using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Domain.Common;
using ProductsApp.Domain.Ports;
using ProductsApp.Infrastructure.DataSource;

namespace ProductsApp.Infrastructure.Adapters;
public class GenericRepository<T> : IRepository<T> where T : DomainEntity
{
    readonly DataContext _context;
    readonly DbSet<T> _dataset;
    readonly char[] _separator = [','];

    public GenericRepository(DataContext context)
    {
        _context = context;
        _dataset = _context.Set<T>();
    }

    public async Task<T> GetOneAsync(Guid id, string? includeStringProperties = default)
    {
        var query = _dataset.AsQueryable();

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            foreach (var includeProperty in includeStringProperties.Split(_separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.FirstOrDefaultAsync(entity => entity.Id == id) ?? default!;
    }

    public async Task<IEnumerable<T>> GetManyAsync(string includeStringProperties = "", bool isTracking = false)
    {
        IQueryable<T> query = _context.Set<T>();

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            foreach (var includeProperty in includeStringProperties.Split
                (_separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
        await _dataset.AddAsync(entity);
        return entity;
    }

    public void UpdateAsync(T entity)
    {
        _dataset.Update(entity);
    }

    public void DeleteAsync(T entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
        _dataset.Remove(entity);
    }

    public async Task<IQueryable<T>> GetPaginationAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeStringProperties = "",
        bool isTracking = false)
    {
        IQueryable<T> query = _context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            foreach (var includeProperty in includeStringProperties
                .Split(_separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            return await Task.FromResult(orderBy(query));
        }

        return (!isTracking) ? await Task.FromResult(query.AsNoTracking()) : await Task.FromResult(query);
    }
    
}
