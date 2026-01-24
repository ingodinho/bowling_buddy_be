using Bowling.Buddy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bowling.Buddy.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; } = default!;
    public DbSet<Group> Groups { get; set; } = default!;
    public DbSet<Game> Games { get; set; } = default!;
    public DbSet<Score> Scores { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}