using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ECommerce.Application.Extensions;

/// <summary>
/// Provides extension methods for registering application layer services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds MediatR, FluentValidation, and HttpContextAccessor services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which services will be added.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(applicationAssembly));

        services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();

        services.AddHttpContextAccessor();
    }
}