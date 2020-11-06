using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Protoss.Core.Events;

namespace Protoss.DataAccess.EF
{
    public static class DomainEventStructureFactory
    {
        public static List<DomainEventStructure> Create(IEnumerable<IDomainEvent> domainEvents)
        {
            return domainEvents.Select(Create).ToList();
        }
        private static DomainEventStructure Create(IDomainEvent domainEvent)
        {
            return new DomainEventStructure()
            {
                Body = JsonConvert.SerializeObject(domainEvent),
                EventId = domainEvent.EventId,
                EventType = domainEvent.GetType().ToString(),
                PublishDateTime = domainEvent.PublishDateTime
            };
        }
    }
}
