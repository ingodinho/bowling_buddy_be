namespace Bowling.Buddy.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IGroupRepository Groups { get; }
    
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task SaveChangesAsync();
}