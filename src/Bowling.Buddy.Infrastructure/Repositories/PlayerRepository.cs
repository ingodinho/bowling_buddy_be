using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;
using Bowling.Buddy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bowling.Buddy.Infrastructure.Repositories;

public class PlayerRepository(AppDbContext appDbContext, ILogger<PlayerRepository> logger) : IPlayerRepository
{
    public async Task<Guid> AddPlayerAsync(Player player, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Adding player {PlayerId}", player.Id);
        var result = await appDbContext.Players
            .AddAsync(player, cancellationToken);
        return result.Entity.Id;
    }

    public async Task<Player?> GetPlayerAsync(Guid playerId, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting player {PlayerId}", playerId);
        var result = await appDbContext.Players
            .Include(p => p.Scores)
            .SingleOrDefaultAsync(p => p.Id == playerId, cancellationToken);

        return result;
    }

    public async Task<ICollection<Player>> GetPlayersForGroupAsync(Guid groupId, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting players for group {groupId}", groupId);
        var result = await appDbContext.Players
            .Where(p => p.GroupId == groupId)
            .ToListAsync(cancellationToken);
        
        logger.LogInformation("Returning players for group {groupId}: {count}", groupId,  result.Count);
        return result;
    }
}