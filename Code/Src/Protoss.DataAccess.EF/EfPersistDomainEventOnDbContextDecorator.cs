using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Protoss.Core;

namespace Protoss.DataAccess.EF
{
    public class EfPersistDomainEventOnDbContextDecorator : DbContext
    {
        private readonly DbContext _dbContext;
        private readonly IDomainEventPersistenceBuilder _eventPersistenceBuilder;

        public EfPersistDomainEventOnDbContextDecorator(DbContext dbContext, IDomainEventPersistenceBuilder eventPersistenceBuilder)
        {
            _dbContext = dbContext;
            _eventPersistenceBuilder = eventPersistenceBuilder;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await new EfDomainEvent(_eventPersistenceBuilder, this._dbContext).Persist();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
