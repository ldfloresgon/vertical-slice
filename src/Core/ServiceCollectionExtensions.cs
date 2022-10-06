using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Vertical.Slice.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediatRPipelines(this IServiceCollection services, Assembly assembly)
    {
        services
            .AddMediatR(assembly)
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}
