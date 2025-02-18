using ProductsApp.Domain.Common;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Entities.Dto;
using ProductsApp.Domain.Exceptions;
using ProductsApp.Domain.Ports;

namespace ProductsApp.Domain.Products.Services;

[DomainService]
public class UpdateProductService
{
    private readonly IRepository<Product> _productRepository;
    public UpdateProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> UpdateAsync(UpdateProductDto editProduct)
    {
        var product = await _productRepository.GetOneAsync(editProduct.Id);
        if (product == null)
        {
            throw new NonExistentProductException($"The product {editProduct.Id} does not exist");
        }

        product.Edit(editProduct.Name, editProduct.Description, editProduct.Category, editProduct.ImageUrl);
        _productRepository.UpdateAsync(product);
        return product;
    }

}
