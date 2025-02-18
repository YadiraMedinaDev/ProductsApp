using MediatR;
using ProductsApp.Application.Products.Command.Dto;

namespace ProductsApp.Application.Products.Query;
public record GetProductAllQuery() : IRequest<IEnumerable<ProductDto>>;

