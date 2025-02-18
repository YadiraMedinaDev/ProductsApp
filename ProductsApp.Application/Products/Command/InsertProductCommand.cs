using MediatR;
using ProductsApp.Application.Products.Command.Dto;

namespace ProductsApp.Application.Products.Command;
public record InsertProductCommand(
    string Name,
    string Description,
    string Category,
    string ImageUrl
    ): IRequest<ProductDto>;
