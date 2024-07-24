using BuildingBlocks.CQRS;

namespace Catalog.Application.Features.Product.GetProduct;

public record GetProductQuery(Guid Id) : IQuery<GetProductResult>;

public record GetProductResult(ProductDto Product);