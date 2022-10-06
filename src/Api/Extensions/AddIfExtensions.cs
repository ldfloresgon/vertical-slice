namespace Vertical.Slice.Extensions;
public static class AddIfExtensions
{
    public static IServiceCollection AddIf(this IServiceCollection services, bool include, Func<IServiceCollection, IServiceCollection> action)
    {
        return include ? action(services) : services;
    }

    public static IApplicationBuilder AddIf(this IApplicationBuilder app, bool include, Func<IApplicationBuilder, IApplicationBuilder> action)
    {
        return include ? action(app) : app;
    }

    public static ControllerActionEndpointConventionBuilder AddIf(this ControllerActionEndpointConventionBuilder endpoint, bool include, Func<ControllerActionEndpointConventionBuilder, ControllerActionEndpointConventionBuilder> action)
    {
        return include ? action(endpoint) : endpoint;
    }
}
