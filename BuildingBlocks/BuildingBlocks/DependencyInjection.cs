using System.Reflection;
using BuildingBlocks.Behaviors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BuildingBlocks;

public static class DependencyInjection
{
    public static IServiceCollection AddBuildingBlocksServices(this IServiceCollection services,
        IConfiguration configuration, Assembly assembly)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddSerilog((hostingContext, loggerFactory) => loggerFactory.ReadFrom.Configuration(configuration));

        return services;
    }
}