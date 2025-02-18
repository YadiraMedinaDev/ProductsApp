using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductsApp.Domain.Entities;

namespace ProductsApp.Infrastructure.DataSource;
public class DataContext : DbContext
{
    private readonly IConfiguration Config;
    public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
    {
        Config = config;
    }

    public DbSet<Product> Products { get; set; } = default!;

    public async Task CommitAsync()
    {
        await SaveChangesAsync().ConfigureAwait(false);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfig());
    }
}
