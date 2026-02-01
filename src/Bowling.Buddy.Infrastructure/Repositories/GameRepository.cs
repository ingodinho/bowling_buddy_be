using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;
using Bowling.Buddy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bowling.Buddy.Infrastructure.Repositories;

public class GameRepository(AppDbContext dbContext, ILogger<GameRepository> logger) : IGameRepository
{
    public async Task<Guid> AddGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Adding game {GameId}", game.Id);
        var result = await dbContext.AddAsync(game, cancellationToken);
        return result.Entity.Id;
    }

    public async Task<Game?> GetGameDetailsByIdAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        var game =  await dbContext.Games
            .Include(g => g.Scores)!
            .ThenInclude(g => g.Player)
            .FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);
        logger.LogInformation("Getting game details for {GameId}", game?.Id);

        return game;
    }

    public async Task<List<Game>> GetAllGamesByGroupAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        var groups = await dbContext.Games
            .Where(g => g.GroupId == groupId)
            .ToListAsync(cancellationToken: cancellationToken);
        
        logger.LogInformation("Getting games for group {GroupId}. Count: {Count}", groupId, groups.Count);
        return groups;
    }
}