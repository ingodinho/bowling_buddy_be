namespace Bowling.Buddy.Application.Models;

public record CreatePlayerRequest(string DisplayName, Guid GroupId);
public record CreatePlayerResponse(Guid Id);
public record PlayerSummaryDto(Guid Id, string DisplayName, Guid GroupId);
public record PlayerDetailDto(Guid Id, string DisplayName, Guid GroupId, List<ScoreDto> Scores);