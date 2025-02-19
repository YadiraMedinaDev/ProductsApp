using AutoMapper;
using MediatR;
using ProductsApp.Application.Ports;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Application.Products.Command;
internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly UpdateProductService _updateProductService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBlobStorageService _blobStorageService;

    public UpdateProductHandler(UpdateProductService updateProductService, IMapper mapper, IUnitOfWork unitOfWork, IBlobStorageService blobStorageService)
    {
        _updateProductService = updateProductService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _blobStorageService = blobStorageService;
    }

    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Image.FileName)}";
        var imageUrl = string.Empty;
        using (var stream = request.Image.OpenReadStream())
        {
            imageUrl = await _blobStorageService.UploadImageAsync(stream, fileName);
        }
        var updateProduct = new Product(request.Id, request.Name, request.Description, request.Category, imageUrl);

        var product = await _updateProductService.UpdateAsync(updateProduct);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }
}
