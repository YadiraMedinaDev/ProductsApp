using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Application.Products.Command;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Application.Products.Query;

namespace ProductsApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetallAsync()
        => await _mediator.Send(new GetProductAllQuery());

    [HttpPost]
    public async Task<ProductDto> Insert([FromForm] InsertProductCommand command)
        => await _mediator.Send(command);

    [HttpPut]
    public async Task<ProductDto> Update(UpdateProductCommand command)
        => await _mediator.Send(command);

    [HttpDelete]
    public async Task<bool> Delete(DeleteProductCommand command)
        => await _mediator.Send(command);
}
