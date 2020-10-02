﻿using System;
using System.Collections.Generic;
using System.Text;
using Protoss.Core.Events.Handlers;

namespace Protoss.Core.Events
{
    public class EventListener : IEventListener
    {
        private readonly IEventAggregator _aggregator;

        public EventListener(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }
        public void Subscribe<T>(Action<T> action) where T : IDomainEvent
        {
            _aggregator.Subscribe(action);
        }

        public void Subscribe<T>(IEventHandler<T> @event) where T : IDomainEvent
        {
            _aggregator.Subscribe(@event);
        }
    }
}
