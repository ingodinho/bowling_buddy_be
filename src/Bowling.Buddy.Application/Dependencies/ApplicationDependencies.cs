using Bowling.Buddy.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bowling.Buddy.Application.Dependencies;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GroupService>();
        services.AddScoped<PlayerService>();
        services.AddScoped<GameService>();
        
        return services;
    }
}