using Bowling.Buddy.Domain.Entities.Interfaces;

namespace Bowling.Buddy.Domain.Entities;

public sealed class Score : IBaseIdEntity
{
    public Guid Id { get; set; }
    public int FinalScore { get; set; }
    public Guid PlayerId { get; set; }
    public Guid GameId { get; set; }
    
    public Game? Game { get; set; }
    public Player? Player { get; set; }
}