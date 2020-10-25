using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protoss.Core.Events;

namespace Protoss.Domain.Tests.Unit.AggregateTests
{
    public class TestDomainEvent : DomainEvent
    {
        public Guid Id { get;private set; }
        public string Name { get;private set; }

        public TestDomainEvent(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
