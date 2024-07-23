using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Mapster;

namespace Catalog.Application.Features.Product.GetProductByCategory;

public class GetProductByCategoryHandler(IProductRepository repository)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await repository.GetByCriteriaAsync(p =>
            p.Category.Equals(request.Category, StringComparison.InvariantCultureIgnoreCase));

        var productDtos = products.Adapt<IEnumerable<ProductDto>>();

        return new GetProductByCategoryResult(productDtos);
    }
}