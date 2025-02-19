using FluentAssertions;
using Moq;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Ports;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Domain.UnitTest.Products.Services;

public class InsertProductServiceTest
{
    [Fact]
    public async Task AddAsync_Success()
    {
        // Arrange
        var repository = new Mock<IRepository<Product>>();
        var product = new Product(Guid.NewGuid(), "Producto1", "Descripcion producto", "Categoria", "url");
        repository.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);
        var service = new InsertProductService(repository.Object);

        // Act
        var insertProduct = await service.AddAsync(product);

        // Assert
        insertProduct.Id.Should().Be(product.Id);
        insertProduct.Should().Be(product);
        repository.Verify(repo => repo.AddAsync(product), Times.Once);
    }
}
