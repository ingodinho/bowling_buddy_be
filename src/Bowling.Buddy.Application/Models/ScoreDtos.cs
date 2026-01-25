namespace Bowling.Buddy.Application.Models;

public record ScoreDto(Guid Id, int FinalScore, Guid PlayerId, Guid GameId);