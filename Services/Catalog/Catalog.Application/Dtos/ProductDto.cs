namespace Catalog.Application.Dtos;

public record ProductDto(Guid Id, string Name, string[] Category, string Description, string ImageFile, decimal Price);