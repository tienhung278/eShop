using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Catalog.Application.Exceptions;
using Mapster;

namespace Catalog.Application.Features.Product.GetProduct;

public class GetProductHandler(IProductRepository repository) : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = (await repository.GetByCriteriaAsync(p => p.Id == request.Id)).SingleOrDefault();
        var productDto = product.Adapt<ProductDto>(ProductMapping.ToDto());
        
        return new GetProductResult(productDto);
    }
}