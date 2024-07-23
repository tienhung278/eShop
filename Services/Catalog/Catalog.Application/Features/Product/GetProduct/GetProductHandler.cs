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
        var product = await repository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new ProductNotFoundException(request.Id);
        }

        var productDto = product.Adapt<ProductDto>();
        return new GetProductResult(productDto);
    }
}