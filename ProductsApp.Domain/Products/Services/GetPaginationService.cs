using ProductsApp.Domain.Common;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Entities.Dto;
using ProductsApp.Domain.Exceptions;
using ProductsApp.Domain.Ports;

namespace ProductsApp.Domain.Products.Services;

[DomainService]
public class GetPaginationService
{
    private readonly IRepository<Product> _productRepository;

    public GetPaginationService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PageList<Product>> GetAsync(GetProductPaginationDto getProductPaginationDto)
    {
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null;
        if (!string.IsNullOrWhiteSpace(getProductPaginationDto.ShortBy))
        {
            if (getProductPaginationDto.ShortBy.ToLower() != "desc"
            && getProductPaginationDto.ShortBy.ToLower() != "asc")
            {
                throw new RequiredFieldException("Invalid sort type.");
            }
        }
        if (getProductPaginationDto.OrderBy.ToLower() == "name")
        {
            orderBy = product => product.OrderBy(order => order.Name);
            if (getProductPaginationDto.ShortBy.ToLower() == "desc")
            {
                orderBy = product => product.OrderByDescending(order => order.Name);
            }
        }
        else if (getProductPaginationDto.OrderBy.ToLower() == "category")
        {
            orderBy = product => product.OrderBy(order => order.Category);
            if (getProductPaginationDto.ShortBy.ToLower() == "desc")
            {
                orderBy = product => product.OrderByDescending(order => order.Category);
            }
        }
        else if (!string.IsNullOrWhiteSpace(getProductPaginationDto.OrderBy))
        {
            throw new RequiredFieldException("You can only sort by name and category.");
        }
        var products = await _productRepository.GetPaginationAsync(
            product => product.Name.Contains(getProductPaginationDto.FilterName)
            && product.Description.Contains(getProductPaginationDto.FilterDescription)
            && product.Category.Contains(getProductPaginationDto.FilterCategory),
            orderBy);

        return PageList<Product>.Create(products, getProductPaginationDto.PageNumber, getProductPaginationDto.PageSize);
    }
}
