using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Product.GetProduct;

public record GetProductQuery(Guid Id) : IQuery<GetProductResult>;

public record GetProductResult(ProductDto Product);