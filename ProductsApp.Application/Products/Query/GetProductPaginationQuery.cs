using MediatR;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Common;

namespace ProductsApp.Application.Products.Query;
public record GetProductPaginationQuery(
    int PageSize = 5,
    int PageNumber = 1,
    string FilterName = "",
    string FilterDescription = "",
    string FilterCategory = "",
    string OrderBy = "",
    string ShortBy = "") : IRequest<PageList<ProductDto>>;

