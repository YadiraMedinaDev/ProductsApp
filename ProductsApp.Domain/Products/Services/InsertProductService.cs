using ProductsApp.Domain.Common;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Ports;

namespace ProductsApp.Domain.Products.Services;

[DomainService]
public class InsertProductService
{
    private readonly IRepository<Product> _productRepository;

    public InsertProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddAsync(Product insertProduct)
    {
        var product = new Product(Guid.Empty, insertProduct.Name, insertProduct.Description, insertProduct.Category, insertProduct.ImageUrl);
        await _productRepository.AddAsync(product);
        return product;
    }

}
