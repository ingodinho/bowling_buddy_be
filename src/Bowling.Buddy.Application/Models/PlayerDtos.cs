namespace Bowling.Buddy.Application.Models;

public record PlayerSummaryDto(Guid Id, string DisplayName, Guid GroupId);
public record PlayerDetailDto(Guid Id, string DisplayName, Guid GroupId, List<ScoreDto> Scores);