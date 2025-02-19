using System.Text.Json.Serialization;
using ProductsApp.Domain.Common;
using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Domain.Entities;

public class Product : DomainEntity
{
    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public string Category { get; private set; } = default!;

    public string ImageUrl { get; private set; } = default!;

    public Product(string name, string description, string category, string imageUrl)
        : this(default!, name, description, category, imageUrl)
    {
    }

    [JsonConstructor]
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
        if (name.Length > 100)
        {
            throw new RequiredFieldException("The name exceeds the 100 characters allowed");
        }
        if (description.Length > 250)
        {
            throw new RequiredFieldException("The description exceeds the 250 characters allowed");
        }
        if (category.Length > 100)
        {
            throw new RequiredFieldException("The category exceeds the 100 characters allowed");
        }
        if (imageUrl.Length > 500)
        {
            throw new RequiredFieldException("The imageUrl exceeds the 500 characters allowed");
        }

        Id = id;
        Name = name;
        Description = description;
        Category = category;
        ImageUrl = imageUrl;
    }
    public void Edit(Product product)
    {
        Name = product.Name;
        Description = product.Description;
        Category = product.Category;
        ImageUrl = product.ImageUrl;
    }
}
