using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IGroupRepository
{
    Task<Guid> AddGroupAsync(Group group);
    Task<ICollection<Group>> GetAllGroupsAsync();
    Task<Group?> GetGroupByIdAsync(Guid groupId, bool includeScores = false);
}