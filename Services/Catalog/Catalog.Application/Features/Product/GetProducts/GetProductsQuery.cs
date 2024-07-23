using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Catalog.Application.Dtos;

namespace Catalog.Application.Features.Product.GetProducts;

public record GetProductsQuery(PaginationRequest PaginationRequest) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<ProductDto> Products);