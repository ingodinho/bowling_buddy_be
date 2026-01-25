using Bowling.Buddy.Domain.Interfaces.Repositories;
using Bowling.Buddy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Bowling.Buddy.Infrastructure.Repositories;

public class UnitOfWork(AppDbContext dbContext, IGroupRepository groups, ILogger<UnitOfWork> logger) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    public IGroupRepository Groups { get; } = groups;

    public async Task BeginTransactionAsync()
    {
        _transaction = await dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction == null)
        {
            return;
        }
        
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
        {
            return;
        }
        
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            foreach (var entry in ex.Entries)
            {
                logger.LogError("Entity {Name} state={EntityState}", entry.Entity.GetType().Name, entry.State);
                logger.LogError(ex.ToString());
            }
        }
    }
}