using MediatR;

namespace ProductsApp.Application.Products.Command;
public record DeleteProductCommand(Guid id) : IRequest<bool>;
