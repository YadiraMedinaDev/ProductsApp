namespace ProductsApp.Application.Ports;
public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken? cancellationToken = null);
}
