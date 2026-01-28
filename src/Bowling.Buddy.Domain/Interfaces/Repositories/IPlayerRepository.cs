using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IPlayerRepository
{
    Task<Guid> AddPlayerAsync(Player player, CancellationToken cancellationToken = default);
    Task<Player?> GetPlayerAsync(Guid playerId, CancellationToken cancellationToken = default);
    Task<ICollection<Player>> GetPlayersForGroupAsync(Guid groupId, CancellationToken cancellationToken = default);
}