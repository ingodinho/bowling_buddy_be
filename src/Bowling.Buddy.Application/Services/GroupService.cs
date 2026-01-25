using Bowling.Buddy.Application.Mappings;
using Bowling.Buddy.Application.Models;
using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Domain.Interfaces.Repositories;

namespace Bowling.Buddy.Application.Services;

public class GroupService(IUnitOfWork unitOfWork)
{
    public async Task<OperationResult<Guid>> CreateGroupAsync(string groupName)
    {
        var groupDbo = new Group
        {
            Id = Guid.NewGuid(),
            Name = groupName
        };
        
        var groupId = await unitOfWork.Groups.AddGroupAsync(groupDbo);
        await unitOfWork.SaveChangesAsync();
        
        return OperationResult<Guid>.Success(groupId);
    }

    public async Task<OperationResult<GroupDetailDto>> GetGroupDetails(Guid groupId, bool includeScores = false)
    {
        var groupDto = await unitOfWork.Groups.GetGroupByIdAsync(groupId, includeScores);

        if (groupDto == null)
        {
            return OperationResult<GroupDetailDto>.NotFound();
        }

        return OperationResult<GroupDetailDto>.Success(groupDto.ToDetailDto());
    }

    public async Task<OperationResult<List<GroupSummaryDto>>> GetAllGroups()
    {
        var dboList = await unitOfWork.Groups.GetAllGroupsAsync();
        var dtoList = dboList.Select(group => group.ToSummaryDto()).ToList();
        return OperationResult<List<GroupSummaryDto>>.Success(dtoList);
    }
}