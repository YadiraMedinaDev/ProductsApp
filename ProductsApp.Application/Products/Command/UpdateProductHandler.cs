using AutoMapper;
using MediatR;
using ProductsApp.Application.Ports;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Entities.Dto;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Application.Products.Command;
internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly UpdateProductService _updateProductService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(UpdateProductService updateProductService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _updateProductService = updateProductService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productDto = _mapper.Map<UpdateProductDto>(request);
        var product = await _updateProductService.UpdateAsync(productDto);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }
}
