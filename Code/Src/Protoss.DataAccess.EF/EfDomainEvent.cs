using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Protoss.Core;
using Protoss.Core.Events;
using Protoss.Domain;

namespace Protoss.DataAccess.EF
{
    public static class EfDomainEvent 
    {
        public static void Persist(ProtossDbContext dbContext)
        {
            var aggregateRoots = dbContext.ChangeTracker
                .Entries<IAggregateRoot>()
                .Select(a => a.Entity)
                .ToList();

            var domainEvents = aggregateRoots
                .SelectMany(aggregateRoot => DomainEventStructureFactory.Create(aggregateRoot.GetEvents()))
                .ToList();

            dbContext.DomainEvents.AddRange(domainEvents);
            aggregateRoots.ForEach(a => a.ClearEvents());
        }
    }
}
