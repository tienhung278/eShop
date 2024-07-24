using Carter;
using Catalog.Application.Features.Product.DeleteProduct;
using Catalog.Application.Features.Product.UpdateProduct;
using Mapster;
using MediatR;

namespace Catalog.Api.Endpoints;

public class DeleteProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/products/{pId}", async (Guid pId, ISender sender) =>
            {
                var command = new DeleteProductCommand(pId);
                
                await sender.Send(command);
 
                return Results.NoContent();
            })
            .WithName("DeleteProduct")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}