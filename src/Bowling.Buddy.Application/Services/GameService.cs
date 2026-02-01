using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;

namespace Bowling.Buddy.Application.Services;

public class GameService(IUnitOfWork unitOfWork)
{
    public async Task<OperationResult<CreateGameResponse>> CreateGameAsync(CreateGameRequest request,
        CancellationToken cancellationToken)
    {
        var gameId =  Guid.NewGuid();
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
}