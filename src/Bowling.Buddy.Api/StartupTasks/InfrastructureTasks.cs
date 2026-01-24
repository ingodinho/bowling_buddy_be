using Bowling.Buddy.Infrastructure.Extensions;

namespace Bowling.Buddy.Api.StartupTasks;

public static class InfrastructureTasks
{
    public static void ApplyInfrastructureStartupTasks(this IServiceProvider services)
    {
        services.ApplyDbMigrations();
    }
}