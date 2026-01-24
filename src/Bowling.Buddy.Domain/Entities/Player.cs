using Bowling.Buddy.Domain.Entities.Interfaces;

namespace Bowling.Buddy.Domain.Entities;

public class Player : IBaseIdEntity
{
    public Guid Id { get; set; }
    public required string DisplayName { get; set; }
    public Guid GroupId { get; set; }
    public Guid? UserId { get; set; }
}