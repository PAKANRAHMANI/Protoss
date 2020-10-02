using System;
using System.Collections.Generic;
using System.Text;
using Protoss.Core.Events;

namespace Protoss.Domain
{
    public interface IAggregateRoot
    {
        void Publish<T>(T @event) where T : IDomainEvent;
        IReadOnlyCollection<IDomainEvent> GetEvents();
        void ClearEvents();
    }
}
