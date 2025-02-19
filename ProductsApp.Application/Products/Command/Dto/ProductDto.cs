namespace ProductsApp.Application.Products.Command.Dto;
public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Category { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;
}
