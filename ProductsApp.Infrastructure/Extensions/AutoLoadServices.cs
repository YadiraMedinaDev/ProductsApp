using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Application.Ports;
using ProductsApp.Domain.Common;
using ProductsApp.Domain.Ports;
using ProductsApp.Infrastructure.Adapters;

namespace ProductsApp.Infrastructure.Extensions;
public static class AutoLoadServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        var _services = AppDomain.CurrentDomain.GetAssemblies()
              .Where(assembly =>
              {
                  return (assembly.FullName is null) || assembly.FullName.Contains("Domain", StringComparison.OrdinalIgnoreCase);
              })
              .SelectMany(assembly => assembly.GetTypes())
              .Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(DomainServiceAttribute)));

        foreach (var service in _services)
        {
            services.AddTransient(service);
        }

        return services;
    }
}
