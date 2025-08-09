using Dorixona.Infrastructure.Data.DbContexts;
using Dorixona.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dorixona.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // PostgreSQL bilan DbContext ni ro'yxatga olish
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorCodesToAdd: null);
            });
        });

        // Generic Repository pattern
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Qo'shimcha infratuzilma xizmatlari
        // services.AddScoped<IFileStorageService, FileStorageService>();
        // services.AddScoped<ILoggingService, LoggingService>();

        return services;
    }
}
