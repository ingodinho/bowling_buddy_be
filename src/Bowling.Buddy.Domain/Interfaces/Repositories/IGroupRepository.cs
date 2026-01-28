using Bowling.Buddy.Domain.Entities;

namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IGroupRepository
{
    Task<Guid> AddGroupAsync(Group group, CancellationToken cancellationToken = default);
    Task<ICollection<Group>> GetAllGroupsAsync(CancellationToken cancellationToken = default);
    Task<Group?> GetGroupByIdAsync(Guid groupId, bool includeScores = false, CancellationToken cancellationToken = default);
}