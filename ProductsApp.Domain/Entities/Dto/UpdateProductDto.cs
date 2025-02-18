namespace ProductsApp.Domain.Entities.Dto;
public class UpdateProductDto
{
    public Guid Id { get; set; }

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public string Category { get; private set; } = default!;

    public string ImageUrl { get; private set; } = default!;
}
