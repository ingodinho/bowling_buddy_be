using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;
using Bowling.Buddy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bowling.Buddy.Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext, ILogger<GroupRepository> logger) : IGroupRepository
{
    public async Task<Guid> AddGroupAsync(Group group)
    {
        logger.LogInformation("AddGroupAsync called with group id {groupId}.", group.Id);
        var result = await appDbContext.Groups.AddAsync(group);
        return result.Entity.Id;
    }

    public async Task<ICollection<Group>> GetAllGroupsAsync()
    {
        var result = await appDbContext.Groups.ToListAsync();
        logger.LogInformation("GetAllGroupsAsync called with group count {count}.", result.Count);
        return result;
    }

    public async Task<Group?> GetGroupByIdAsync(Guid groupId, bool includeScores = false)
    {
        logger.LogInformation("GetGroupById called with id {groupId}.", groupId);
        var query = appDbContext.Groups
            .Include(g => g.Games)
            .Include(g => g.Players)
            .AsQueryable();

        if (includeScores)
        {
            query = query.Include(x => x.Games)!.ThenInclude(g => g.Scores);
        }

        return await query.AsSplitQuery()
            .FirstOrDefaultAsync(g => g.Id == groupId);
    }
}