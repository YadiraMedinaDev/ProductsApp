using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsApp.Domain.Entities;

namespace ProductsApp.Infrastructure.DataSource;
internal class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(product => product.Id).IsRequired();

        builder.Property(product => product.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(product => product.Category)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(product => product.ImageUrl)
            .HasMaxLength(500)
            .IsRequired();
    }
}
