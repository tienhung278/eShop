using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Product.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<ProductDto> ProductDtos);