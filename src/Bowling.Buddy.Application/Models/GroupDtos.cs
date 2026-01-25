namespace Bowling.Buddy.Application.Models;

public record CreateGroupRequest(string Name);
public record GroupSummaryDto(Guid Id, string Name);
public record GroupDetailDto(Guid Id, string Name, List<PlayerSummaryDto> Players, List<GameDetailDto> Games);