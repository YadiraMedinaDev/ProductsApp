using ProductsApp.Domain.Common;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Ports;

namespace ProductsApp.Domain.Products.Services;

[DomainService]
public class QueryProductService
{
    private IRepository<Product> _productRepository;

    public QueryProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var listProduct = await _productRepository.GetManyAsync();
        return listProduct;
    }
}
