namespace Bowling.Buddy.Application.Models;

public record GameSummaryDto(Guid Id, DateTime DateTime, string? Description, Guid GroupId);
public record GameDetailDto(Guid Id, DateTime DateTime, string? Description, Guid GroupId, List<ScoreDto> Scores);
public record CreateGameRequest(DateTime DateTime, string? Description, Guid GroupId, List<CreateScoreDto> Scores);

public record CreateGameResponse(Guid Id);
public record CreateScoreDto(Guid GameId, Guid PlayerId, int FinalScore);
