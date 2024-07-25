namespace Catalog.Domain.Models;

public class Product : Entity
{
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }
}