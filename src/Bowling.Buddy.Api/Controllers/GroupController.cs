using Bowling.Buddy.Api.OperationResultExtensions;
using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bowling.Buddy.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GroupController(GroupService groupService, ILogger<GroupController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request)
    {
        var result = await groupService.CreateGroupAsync(request.Name);
        return result.ToActionResult(this);
    }

    [HttpGet]
    [Route("{groupId:guid}")]
    public async Task<IActionResult> GetGroup(Guid groupId, [FromQuery] bool includeScores = false)
    {
        var result = await groupService.GetGroupDetails(groupId, includeScores);
        return result.ToActionResult(this);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllGroups()
    {
        var result = await groupService.GetAllGroups();
        return result.ToActionResult(this);
    }
}