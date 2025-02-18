using ProductsApp.Domain.Common;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Exceptions;
using ProductsApp.Domain.Ports;

namespace ProductsApp.Domain.Products.Services;

[DomainService]
public class DeleteProductService
{
    private readonly IRepository<Product> _productRepository;

    public DeleteProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> DeleteAsync(Guid id)
    {
        var product =await _productRepository.GetOneAsync(id);
        if (product==null)
        {
            throw new NonExistentProductException($"The product {id} does not exist");
        }

        _productRepository.DeleteAsync(product);
        return product;
    }
}
