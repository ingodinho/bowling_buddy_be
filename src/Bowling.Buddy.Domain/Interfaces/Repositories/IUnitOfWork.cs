namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IGroupRepository Groups { get; }
    IPlayerRepository Players { get; }
    
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}