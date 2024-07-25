using Carter;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Product.UpdateProduct;
using Mapster;
using MediatR;

namespace Catalog.Api.Endpoints;

public record UpdateProductRequest(ProductDto Product, Guid ActedBy);

public class UpdateProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/products", async (UpdateProductRequest request, ISender sender) =>
            {
                request = request with { ActedBy = Guid.NewGuid() };
                var command = request.Adapt<UpdateProductCommand>();
                await sender.Send(command);

                return Results.NoContent();
            })
            .WithName("UpdateProduct")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}