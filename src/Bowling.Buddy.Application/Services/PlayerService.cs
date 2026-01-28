using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;

namespace Bowling.Buddy.Application.Services;

public class PlayerService(IUnitOfWork unitOfWork)
{
    public async Task<OperationResult<CreatePlayerResponse>> CreatePlayer(CreatePlayerRequest request,
        CancellationToken cancellationToken)
    {
        var playerDbo = new Player
        {
            Id = Guid.NewGuid(),
            DisplayName = request.DisplayName,
            GroupId = request.GroupId
        };

        var result = await unitOfWork.Players.AddPlayerAsync(playerDbo, cancellationToken);
        
        return OperationResult<CreatePlayerResponse>.Success(new CreatePlayerResponse(result));
    }
}