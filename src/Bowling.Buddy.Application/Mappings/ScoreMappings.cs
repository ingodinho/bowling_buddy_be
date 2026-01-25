using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Application.Mappings;

public static class ScoreMappings
{
    public static ScoreDto ToDto(this Score score)
    {
        return new ScoreDto(score.Id, score.FinalScore, score.PlayerId, score.GameId);
    }
}