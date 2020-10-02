using System;

namespace Protoss.Core.Events
{
    public interface IDomainEvent : IEvent
    {
        Guid EventId { get; }
        DateTime PublishDateTime { get; }
    }
}
