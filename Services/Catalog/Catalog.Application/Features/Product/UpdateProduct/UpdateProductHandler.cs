using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Catalog.Application.Exceptions;
using MediatR;

namespace Catalog.Application.Features.Product.UpdateProduct;

public class UpdateProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Domain.Models.Product>();
        var product = await repository.GetByIdAsync(request.Product.Id);
        if (product == null) throw new ProductNotFoundException(request.Product.Id);

        UpdateProductWithNewValue(product, request.Product);

        await repository.UpdateAsync(product, Guid.NewGuid());
        await unitOfWork.SaveChangesAsync();
        
        return await Task.FromResult(Unit.Value);
    }

    private void UpdateProductWithNewValue(Domain.Models.Product product, ProductDto requestProduct)
    {
        product.Update(requestProduct.Name, requestProduct.Category, requestProduct.Description,
            requestProduct.ImageFile, requestProduct.Price);
    }
}