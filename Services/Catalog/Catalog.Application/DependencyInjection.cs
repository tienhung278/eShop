using System.Reflection;
using BuildingBlocks;
using Catalog.Application.Features.Product.CreateProduct;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddBuildingBlocksServices(configuration, Assembly.GetExecutingAssembly());
        services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
        services.AddFeatureManagement();

        return services;
    }
}