using AutoMapper;
using MediatR;
using ProductsApp.Application.Ports;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Application.Products.Command;
public class InsertProductHandler : IRequestHandler<InsertProductCommand, ProductDto>
{
    private readonly InsertProductService _insertProductService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBlobStorageService _blobStorageService;

    public InsertProductHandler(InsertProductService insertProductService, IMapper mapper, IUnitOfWork unitOfWork, IBlobStorageService blobStorageService)
    {
        _insertProductService = insertProductService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _blobStorageService = blobStorageService;
    }

    public async Task<ProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Image.FileName)}";
        var imageUrl = string.Empty;
        using (var stream = request.Image.OpenReadStream())
        {
            imageUrl = await _blobStorageService.UploadImageAsync(stream, fileName);
        }
        var insertProduct = new Product(request.Name, request.Description, request.Category, imageUrl);

        var product = await _insertProductService.AddAsync(insertProduct);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }
}
