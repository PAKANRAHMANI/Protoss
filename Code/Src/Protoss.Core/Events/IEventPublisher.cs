using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Core.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
