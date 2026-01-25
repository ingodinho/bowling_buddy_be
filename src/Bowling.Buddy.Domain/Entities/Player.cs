using Bowling.Buddy.Domain.Entities.Interfaces;

namespace Bowling.Buddy.Domain.Entities;

public sealed class Player : IBaseIdEntity
{
    public Guid Id { get; set; }
    public required string DisplayName { get; set; }
    public Guid GroupId { get; set; }
    
    public Group? Group { get; set; }
    public ICollection<Score>? Scores { get; set; } = new HashSet<Score>();
}