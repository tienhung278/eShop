using BuildingBlocks.CQRS;
using Catalog.Application.Dtos;
using FluentValidation;
using Mapster;

namespace Catalog.Application.Features.Product.UpdateProduct;

public record UpdateProductCommand(ProductDto Product, Guid ActedBy) : ICommand;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Product.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Product.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}