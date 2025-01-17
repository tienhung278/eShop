﻿using BuildingBlocks.CQRS;
using Catalog.Application.Data;
using Catalog.Application.Exceptions;
using MediatR;

namespace Catalog.Application.Features.Product.DeleteProduct;

public class DeleteProductHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteProductCommand>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Domain.Models.Product>();
        var product = (await repository.GetByCriteriaAsync(p => p.Id == request.Id)).SingleOrDefault();
        if (product == null) throw new ProductNotFoundException(request.Id);

        await repository.DeleteAsync(product, request.ActedBy);
        await unitOfWork.SaveChangesAsync();

        return await Task.FromResult(Unit.Value);
    }
}