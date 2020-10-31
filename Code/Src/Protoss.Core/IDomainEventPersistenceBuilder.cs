using System;
using System.Collections.Generic;
using System.Text;
using Protoss.Core.Events;

namespace Protoss.Core
{
    public interface IDomainEventPersistenceBuilder
    {
        IDomainEventPersistenceBuilder WithTableName(string name);
        IDomainEventPersistenceBuilder WithColumn(string columnName, Func<IDomainEvent, object> valueProvider);
        Dictionary<string, Func<IDomainEvent, object>> GetColumns();
        string Build();
    }
}
