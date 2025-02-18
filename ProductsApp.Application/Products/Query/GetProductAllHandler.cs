using AutoMapper;
using MediatR;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Application.Products.Query;
internal class GetProductAllHandler : IRequestHandler<GetProductAllQuery, IEnumerable<ProductDto>>
{
    private readonly QueryProductService _queryProductService;
    private readonly IMapper _mapper;

    public GetProductAllHandler(QueryProductService queryProductService, IMapper mapper)
    {
        _queryProductService = queryProductService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductAllQuery request, CancellationToken cancellationToken)
    {
        var listProduct = await _queryProductService.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(listProduct);
    }
}
