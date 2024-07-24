using BuildingBlocks.Pagination;
using Carter;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Product.GetProducts;
using Mapster;
using MediatR;

namespace Catalog.Api.Endpoints;

public record GetProductsResponse(IEnumerable<ProductDto> Products);

public class GetProducts : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var query = new GetProductsQuery(request);

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}