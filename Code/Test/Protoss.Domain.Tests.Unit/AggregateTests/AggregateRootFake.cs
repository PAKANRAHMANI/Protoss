using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Protoss.Core.Events;

namespace Protoss.Domain.Tests.Unit.AggregateTests
{
    public class AggregateRootFake: AggregateRoot<Guid>
    {
        public AggregateRootFake()
        {
            
        }
        public AggregateRootFake(IEventPublisher publisher):base(publisher)
        {
            
        }
    }
}
