using BuildingBlocks.CQRS;
using FluentValidation;

namespace Catalog.Application.Features.Product.DeleteProduct;

public record DeleteProductCommand(Guid Id, Guid ActedBy) : ICommand;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id is required");
    }
}