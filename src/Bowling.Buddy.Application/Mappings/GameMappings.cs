using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Application.Mappings;

public static class GameMappings
{
    public static GameSummaryDto ToSummaryDto(this Game game)
    {
        return new GameSummaryDto(game.Id, game.DateTime, game.Description, game.GroupId);
    }

    public static GameDetailDto ToDetailDto(this Game game)
    {
        var scores = game.Scores?.Select(score => score.ToDto()).ToList() ?? [];
        return new GameDetailDto(game.Id, game.DateTime, game.Description, game.GroupId, scores);
    }
}