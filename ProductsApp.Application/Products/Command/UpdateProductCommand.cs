using MediatR;
using Microsoft.AspNetCore.Http;
using ProductsApp.Application.Products.Command.Dto;

namespace ProductsApp.Application.Products.Command;
public record UpdateProductCommand (
    Guid Id,
    string Name,
    string Description,
    string Category,
    IFormFile Image
    ) : IRequest<ProductDto>;

