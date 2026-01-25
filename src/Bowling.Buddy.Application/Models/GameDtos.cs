namespace Bowling.Buddy.Application.Models;

public record GameSummaryDto(Guid Id, DateTime DateTime, string? Description, Guid GroupId);
public record GameDetailDto(Guid Id, DateTime DateTime, string? Description, Guid GroupId, List<ScoreDto> Scores);