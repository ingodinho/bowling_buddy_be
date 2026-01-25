using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Application.Mappings;

public static class GroupMappings
{
    public static GroupSummaryDto ToSummaryDto(this Group group)
    {
        return new GroupSummaryDto(group.Id, group.Name);
    }

    public static GroupDetailDto ToDetailDto(this Group group)
    {
        var players = group.Players?.Select(p => p.ToSummaryDto()).ToList() ?? [];
        var games = group.Games?.Select(g => g.ToDetailDto()).ToList() ?? [];
        return new GroupDetailDto(group.Id, group.Name, players, games);
    }
}