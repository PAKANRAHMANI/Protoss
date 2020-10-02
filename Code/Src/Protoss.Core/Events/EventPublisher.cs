using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Core.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IEventAggregator _aggregator;

        public EventPublisher(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }
        public void Publish<T>(T @event) where T : IEvent
        {
            _aggregator.Publish(@event);
        }
    }
}
