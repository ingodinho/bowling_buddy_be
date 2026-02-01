using Bowling.Buddy.Api.OperationResultExtensions;
using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bowling.Buddy.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GameController(GameService gameService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest request, CancellationToken cancellationToken)
    {
        var result = await gameService.CreateGameAsync(request, cancellationToken);
        return result.ToActionResult(this);
    }

    [HttpGet]
    [Route("group")]
    public async Task<IActionResult> GetGamesForGroup([FromQuery] Guid groupId, CancellationToken cancellationToken)
    {
        var result = await gameService.GetAllGamesForGroupAsync(groupId, cancellationToken);
        return result.ToActionResult(this);
    }

    [HttpGet]
    public async Task<IActionResult> GetGameDetails([FromQuery] Guid gameId, CancellationToken cancellationToken)
    {
        var result = await gameService.GetGameDetailsAsync(gameId, cancellationToken);
        return result.ToActionResult(this);
    }
}