﻿using AutoMapper;
using ProductsApp.Application.Products.Command;
using ProductsApp.Application.Products.Command.Dto;
using ProductsApp.Application.Products.Query;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Entities.Dto;

namespace ProductsApp.Application.Products;
public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<UpdateProductCommand, Product>();
        CreateMap<InsertProductCommand, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<GetProductPaginationQuery, GetProductPaginationDto>();
    }
}
