using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Protoss.Domain;

namespace Protoss.DataAccess.EF
{
    public abstract class EfRepository<TKey, T> : IRepository<TKey, T> where T : class, IAggregateRoot
    {
        private readonly DbContext _dbContext;

        protected EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract Task<TKey> GetNextId();

        public async Task Create(T aggregate)
        {
            await _dbContext.Set<T>().AddAsync(aggregate);
        }

        public Task Remove(T aggregate)
        {
            _dbContext.Set<T>().Remove(aggregate);
            return Task.CompletedTask;
        }

        public async Task<T> Get(TKey key)
        {
            return await _dbContext.Set<T>().FindAsync(key);
        }
    }
}
