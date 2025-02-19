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

    public async Task<Product> AddAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        return product;
    }

}
