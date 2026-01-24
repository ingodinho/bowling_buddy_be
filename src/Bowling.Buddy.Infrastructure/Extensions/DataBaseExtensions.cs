using Bowling.Buddy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bowling.Buddy.Infrastructure.Extensions;

public static class DataBaseExtensions
{
    public static void ApplyDbMigrations(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger(typeof(DataBaseExtensions));
        
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isTestEnvironment = environment == "Testing";

        if (isTestEnvironment)
        {
            return;
        }
        
        var pendingMigrations = dbContext.Database.GetPendingMigrations().ToList();
        if (pendingMigrations.Count != 0)
        {
            logger.LogInformation("Applying database migrations on startup: {Migrations}", string.Join(", ", pendingMigrations));
            dbContext.Database.Migrate();
        }
        else
        {
            logger.LogInformation("No pending migrations in app startup");
        }
    }
}