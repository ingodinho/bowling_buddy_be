using Microsoft.EntityFrameworkCore;

namespace Bowling.Buddy.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
}