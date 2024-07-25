using Carter;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Product.CreateProduct;
using Mapster;
using MediatR;

namespace Catalog.Api.Endpoints;

public record CreateProductRequest(ProductDto Product);

public record CreateProductResponse(Guid Id);

public class CreateProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/api/products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
    }
}