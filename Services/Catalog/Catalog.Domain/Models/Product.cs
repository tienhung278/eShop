namespace Catalog.Domain.Models;

public class Product : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }

    public void Update(string name, string category, string description, string imageFile, decimal price)
    {
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }
}