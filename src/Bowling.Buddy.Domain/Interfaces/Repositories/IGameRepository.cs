using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IGameRepository
{
    Task<Guid> AddGameAsync(Game game, CancellationToken cancellationToken = default);
    Task<Game?> GetGameDetailsByIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task<List<Game>> GetAllGamesByGroupAsync(Guid groupId, CancellationToken cancellationToken = default);
}