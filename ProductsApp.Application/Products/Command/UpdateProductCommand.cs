using MediatR;
using ProductsApp.Application.Products.Command.Dto;

namespace ProductsApp.Application.Products.Command;
public record UpdateProductCommand (
    Guid Id,
    string Name,
    string Description,
    string Category,
    string ImageUrl): IRequest<ProductDto>;

