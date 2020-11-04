using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Protoss.Core;

namespace Protoss.DataAccess.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IDomainEventPersistenceBuilder _eventPersistenceBuilder;
        private IDbContextTransaction _transaction;
        public EfUnitOfWork(DbContext dbContext, IDomainEventPersistenceBuilder eventPersistenceBuilder)
        {
            _dbContext = dbContext;
            _eventPersistenceBuilder = eventPersistenceBuilder;
        }
        public async Task Begin()
        {
            this._transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            await Task.CompletedTask;
        }

        public async Task Commit()
        {
            await new EfDomainEvent(_eventPersistenceBuilder, this._dbContext).Persist();
            await _dbContext.Database.CurrentTransaction.CommitAsync();
        }

        public async Task RollBack()
        {
            await this._transaction.RollbackAsync();
        }
    }
}
