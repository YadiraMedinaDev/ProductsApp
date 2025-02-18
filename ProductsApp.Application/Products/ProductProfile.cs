using AutoMapper;
using ProductsApp.Application.Products.Command;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Domain.Entities;

namespace ProductsApp.Application.Products;
public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<InsertProductCommand, Product>();
        CreateMap<Product, ProductDto>();
    }
}
