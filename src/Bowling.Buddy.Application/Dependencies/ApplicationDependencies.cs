using Bowling.Buddy.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bowling.Buddy.Application.Dependencies;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddScoped<GroupService>();
    }
}