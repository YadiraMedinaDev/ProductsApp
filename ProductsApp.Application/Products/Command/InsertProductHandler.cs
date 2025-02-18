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

    public InsertProductHandler(InsertProductService insertProductService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _insertProductService = insertProductService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
    {
        var insertProduct = _mapper.Map<Product>(request);
        var product = await _insertProductService.AddAsync(insertProduct);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<ProductDto>(product);
    }
}
