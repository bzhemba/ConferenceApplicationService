using Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        }).AddDbContext<ActivityDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<IApplicationDbContext>());
        services.AddScoped<IActivityDbContext>(provider =>
            provider.GetService<IActivityDbContext>());
        return services;
        
    }
}