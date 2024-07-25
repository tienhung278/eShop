using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Dtos;
using Catalog.Application.Exceptions;
using Mapster;
using MediatR;

namespace Catalog.Application.Features.Product.UpdateProduct;

public class UpdateProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Domain.Models.Product>();
        var product = (await repository.GetByCriteriaAsync(p => p.Id == request.Product.Id)).SingleOrDefault();
        if (product == null) throw new ProductNotFoundException(request.Product.Id);
        
        product = request.Product.Adapt<Domain.Models.Product>(ProductMapping.ToEntity());
        await repository.UpdateAsync(product, request.ActedBy);
        await unitOfWork.SaveChangesAsync();

        return await Task.FromResult(Unit.Value);
    }
}