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
        private readonly ProtossDbContext _dbContext;
        private IDbContextTransaction _transaction;
        public EfUnitOfWork(ProtossDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Begin()
        {
            this._transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            await Task.CompletedTask;
        }

        public async Task Commit()
        {
            await _dbContext.Database.CurrentTransaction.CommitAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task RollBack()
        {
            await this._transaction.RollbackAsync();
        }
    }
}
