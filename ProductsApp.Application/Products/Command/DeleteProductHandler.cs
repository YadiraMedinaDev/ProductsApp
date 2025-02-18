using MediatR;
using ProductsApp.Application.Ports;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Application.Products.Command;
internal class DeleteProductHandler :IRequestHandler<DeleteProductCommand, bool>
{
    private readonly DeleteProductService _deleteProductService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductHandler(DeleteProductService deleteProductService, IUnitOfWork unitOfWork)
    {
        _deleteProductService = deleteProductService;
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _deleteProductService.DeleteAsync(request.id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}
