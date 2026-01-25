using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Application.Mappings;

public static class PlayerMappings
{
    public static PlayerSummaryDto ToSummaryDto(this Player player)
    {
        return new PlayerSummaryDto(player.Id, player.DisplayName, player.GroupId);
    }

    public static PlayerDetailDto ToDetailDto(this Player player)
    {
        var scores = player.Scores?.Select(s => s.ToDto()).ToList() ?? [];
        return new PlayerDetailDto(player.Id, player.DisplayName, player.GroupId, scores);
    }
}