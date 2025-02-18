using ProductsApp.Domain.Common;
using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Domain.Entities;
public class Product : DomainEntity
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Category { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public Product(string name, string description, string category, string imageUrl)
        : this(default!, name, description, category, imageUrl)
    {
    }

    public Product(Guid id, string name, string description, string category, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new RequiredFieldException("The name field cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new RequiredFieldException("The description field cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new RequiredFieldException("The category field cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            throw new RequiredFieldException("The imageUrl field cannot be null or empty");
        }


        Id = id;
        Name = name;
        Description = description;
        Category = category;
        ImageUrl = imageUrl;
    }
    public void Edit(string name, string description, string category, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new RequiredFieldException("The name field cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new RequiredFieldException("The description field cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new RequiredFieldException("The category field cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            throw new RequiredFieldException("The imageUrl field cannot be null or empty");
        }

        Name = name;
        Description = description;
        Category = category;
        ImageUrl = imageUrl;
    }
}
