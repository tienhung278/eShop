using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Product.GetProduct;
using Mapster;

namespace Catalog.Application.Features.Product.GetProducts;

public record GetProductsQuery(PaginationRequest PaginationRequest) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<ProductDto> Products);