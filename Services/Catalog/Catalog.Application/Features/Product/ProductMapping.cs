using Catalog.Application.Dtos;
using Mapster;

namespace Catalog.Application.Features.Product;

public class ProductMapping
{
    public static TypeAdapterConfig ToEntity()
    {
        var config = new TypeAdapterConfig();
        config.NewConfig<ProductDto, Domain.Models.Product>()
            .Map(dst => dst.Category, src => string.Join(',', src.Category));
        
        return config;
    }
    
    public static TypeAdapterConfig ToDto()
    {
        var config = new TypeAdapterConfig();
        config.NewConfig<Domain.Models.Product, ProductDto>()
            .Map(dst => dst.Category, src => src.Category.Split(',', StringSplitOptions.RemoveEmptyEntries));
        
        return config;
    }
    
    public static TypeAdapterConfig ToListDto()
    {
        var config = new TypeAdapterConfig();
        config.NewConfig<IEnumerable<Domain.Models.Product>, IEnumerable<ProductDto>>()
            .MapWith(src => src.Select(p => p.Adapt<ProductDto>(ToDto())));
        
        return config;
    }
}