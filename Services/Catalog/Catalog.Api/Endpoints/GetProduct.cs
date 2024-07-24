using Carter;
using Catalog.Application.Features.Product.GetProduct;
using Mapster;
using MediatR;

namespace Catalog.Api.Endpoints;

public record GetProductResponse(ProductDto Product);

public class GetProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products/{pId}", async (Guid pId, ISender sender) =>
            {
                var query = new GetProductQuery(pId);

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProduct")
            .Produces<GetProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product")
            .WithDescription("Get Product");
    }
}