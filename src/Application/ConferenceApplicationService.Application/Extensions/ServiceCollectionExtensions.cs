using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceApplicationService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}