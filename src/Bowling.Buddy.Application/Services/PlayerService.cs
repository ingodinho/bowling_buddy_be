using Bowling.Buddy.Application.Mappings;
using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;

namespace Bowling.Buddy.Application.Services;

public class PlayerService(IUnitOfWork unitOfWork)
{
    public async Task<OperationResult<CreatePlayerResponse>> CreatePlayerAsync(CreatePlayerRequest request,
        CancellationToken cancellationToken)
    {
        var playerDbo = new Player
        {
            Id = Guid.NewGuid(),
            DisplayName = request.DisplayName,
            GroupId = request.GroupId
        };

        var result = await unitOfWork.Players.AddPlayerAsync(playerDbo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return OperationResult<CreatePlayerResponse>.Success(new CreatePlayerResponse(result));
    }

    public async Task<OperationResult<List<PlayerSummaryDto>>> GetPlayersForGroupAsync(Guid groupId, CancellationToken cancellationToken)
    {
        var playersDbo = await unitOfWork.Players.GetPlayersForGroupAsync(groupId, cancellationToken);
        var playersDto = playersDbo.Select(p => p.ToSummaryDto()).ToList();

        return OperationResult<List<PlayerSummaryDto>>.Success(playersDto);
    }

    public async Task<OperationResult<PlayerDetailDto>> GetPlayerDetailsAsync(Guid playerId,
        CancellationToken cancellationToken)
    {
        var playerDbo = await unitOfWork.Players.GetPlayerAsync(playerId, cancellationToken);

        if (playerDbo == null)
        {
            return OperationResult<PlayerDetailDto>.NotFound();
        }

        return OperationResult<PlayerDetailDto>.Success(playerDbo.ToDetailDto());
    }
}