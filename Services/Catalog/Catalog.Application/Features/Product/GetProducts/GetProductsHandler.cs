using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Mapster;

namespace Catalog.Application.Features.Product.GetProducts;

public class GetProductsHandler(IProductRepository repository) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repository.GetAllAsync(request.PaginationRequest);
        var productDtos = products.Adapt<IEnumerable<ProductDto>>();

        return new GetProductsResult(productDtos);
    }
}