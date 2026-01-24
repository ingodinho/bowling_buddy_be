using Bowling.Buddy.Domain.Entities.Interfaces;

namespace Bowling.Buddy.Domain.Entities;

public sealed class Group : IBaseIdEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    public ICollection<Player> Players { get; set; }  = new HashSet<Player>();
}