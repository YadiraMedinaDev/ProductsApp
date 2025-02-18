using ProductsApp.Application.Ports;
using ProductsApp.Infrastructure.DataSource;

namespace ProductsApp.Infrastructure.Adapters;
public class UnitOfWork(DataContext context): IUnitOfWork
{
    public async Task SaveAsync(CancellationToken? cancellationToken = null)
    {
        var token = cancellationToken ?? new CancellationTokenSource().Token;

        await context.SaveChangesAsync(token);
    }
}
