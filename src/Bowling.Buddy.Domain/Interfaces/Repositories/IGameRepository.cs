using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IGameRepository
{
    Task<Guid> AddGameAsync(Game game, CancellationToken cancellationToken);
    Task<Game> GetGameDetailsByIdAsync(Guid gameId, CancellationToken cancellationToken);
    Task<List<Game>> GetAllGamesByGroupAsync(Guid groupId, CancellationToken cancellationToken);
}