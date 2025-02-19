using AutoMapper;
using MediatR;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Common;
using ProductsApp.Domain.Entities.Dto;
using ProductsApp.Domain.Products.Services;

namespace ProductsApp.Application.Products.Query;
internal class GetProductPaginationHandler(GetPaginationService getPaginationService, IMapper mapper)
    : IRequestHandler<GetProductPaginationQuery, PageList<ProductDto>>
{
    public async Task<PageList<ProductDto>> Handle(GetProductPaginationQuery request, CancellationToken cancellationToken)
    {
        var getProductPaginationDto = mapper.Map<GetProductPaginationDto>(request);
        var pageProducts = await getPaginationService.GetAsync(getProductPaginationDto);
        var productsDto = mapper.Map<IEnumerable<ProductDto>>(pageProducts);
        var page = new PageList<ProductDto>(productsDto, pageProducts.Count, pageProducts.CurrentPage, pageProducts.PageSize);
        return page;
    }
}
