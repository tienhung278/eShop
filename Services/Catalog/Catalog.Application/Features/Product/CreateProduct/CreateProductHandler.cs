using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Mapster;

namespace Catalog.Application.Features.Product.CreateProduct;

public class CreateProductHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Domain.Models.Product>();
        var product = request.Product.Adapt<Domain.Models.Product>(ProductMapping.ToEntity());
        var pId = await repository.CreateAsync(product, request.ActedBy);
        await unitOfWork.SaveChangesAsync();

        return new CreateProductResult(pId);
    }
}