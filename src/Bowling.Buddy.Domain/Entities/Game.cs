using Bowling.Buddy.Domain.Entities.Interfaces;

namespace Bowling.Buddy.Domain.Entities;

public sealed class Game : IBaseIdEntity
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public Guid GroupId { get; set; }
    public string? Description { get; set; }
    
    public Group? Group { get; set; }
    public ICollection<Score>? Scores { get; set; } = new HashSet<Score>();
}