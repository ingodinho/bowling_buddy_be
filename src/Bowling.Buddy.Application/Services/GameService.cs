using Bowling.Buddy.Application.Mappings;
using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;

namespace Bowling.Buddy.Application.Services;

public class GameService(IUnitOfWork unitOfWork)
{
    public async Task<OperationResult<CreateGameResponse>> CreateGameAsync(CreateGameRequest request,
        CancellationToken cancellationToken)
    {
        var gameId = Guid.NewGuid();
        var scores = request.Scores.Select(s => new Score
        {
            Id = Guid.NewGuid(),
            FinalScore = s.FinalScore,
            PlayerId = s.PlayerId,
            GameId = gameId
        }).ToList();

        var gameDbo = new Game
        {
            Id = gameId,
            GroupId = request.GroupId,
            DateTime = request.DateTime,
            Description = request.Description,
            Scores = scores
        };

        var result = await unitOfWork.Games.AddGameAsync(gameDbo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return OperationResult<CreateGameResponse>.Success(new CreateGameResponse(result));
    }

    public async Task<OperationResult<GameDetailDto>> GetGameDetailsAsync(Guid gameId,
        CancellationToken cancellationToken)
    {
        var gameDbo = await unitOfWork.Games.GetGameDetailsByIdAsync(gameId, cancellationToken);

        if (gameDbo == null)
        {
            return OperationResult<GameDetailDto>.NotFound();
        }

        return OperationResult<GameDetailDto>.Success(gameDbo.ToDetailDto());
    }

    public async Task<OperationResult<List<GameDetailDto>>> GetAllGamesForGroupAsync(Guid groupId,
        CancellationToken cancellationToken)
    {
        var games = await unitOfWork.Games.GetAllGamesByGroupAsync(groupId, cancellationToken);
        var gamesDto = games.Select(g => g.ToDetailDto()).ToList();

        return OperationResult<List<GameDetailDto>>.Success(gamesDto);
    }
}