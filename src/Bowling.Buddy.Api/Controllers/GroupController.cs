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
        return Ok(result.Model);
    }
}