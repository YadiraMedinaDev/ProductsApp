namespace ProductsApp.Domain.Entities.Dto;

public record GetProductPaginationDto(
    int PageSize = 5,
    int PageNumber = 1,
    string FilterName = "",
    string FilterDescription = "",
    string FilterCategory = "",
    string OrderBy = "",
    string ShortBy = "");
