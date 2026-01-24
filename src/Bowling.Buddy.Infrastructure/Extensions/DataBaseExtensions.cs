using Bowling.Buddy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bowling.Buddy.Infrastructure.Extensions;

public static class DataBaseExtensions
{
    public static void ApplyDbMigrations(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        // var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
        
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isTestEnvironment = environment == "Testing";

        if (isTestEnvironment)
        {
            return;
        }
        
        var pendingMigrations = dbContext.Database.GetPendingMigrations().ToList();
        if (pendingMigrations.Count != 0)
        {
            Console.WriteLine($"Applying database migrations on startup: {string.Join(", ", pendingMigrations)}");
            dbContext.Database.Migrate();
        }
        else
        {
            Console.WriteLine("No pending migrations in app startup");
        }
    }
}