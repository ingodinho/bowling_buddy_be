using Bowling.Buddy.Api.OperationResultExtensions;
using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bowling.Buddy.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlayerController(PlayerService playerService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequest request,
        CancellationToken cancellationToken)
    {
        var  result = await playerService.CreatePlayerAsync(request, cancellationToken);
        return result.ToActionResult(this);
    }

    [HttpGet]
    [Route("group")]
    public async Task<IActionResult> GetPlayersForGroup([FromQuery] Guid groupId, CancellationToken cancellationToken)
    {
        var result = await playerService.GetPlayersForGroupAsync(groupId, cancellationToken);
        return result.ToActionResult(this);
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayerDetails([FromQuery] Guid playerId, CancellationToken cancellationToken)
    {
        var result = await playerService.GetPlayerDetailsAsync(playerId, cancellationToken);
        return result.ToActionResult(this);
    }
}