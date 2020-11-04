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
    public class EfDomainEvent
    {
        private readonly IDomainEventPersistenceBuilder _eventPersistenceBuilder;
        private readonly DbContext _dbContext;

        public EfDomainEvent(IDomainEventPersistenceBuilder eventPersistenceBuilder, DbContext dbContext)
        {
            _eventPersistenceBuilder = eventPersistenceBuilder;
            _dbContext = dbContext;
        }
        public async Task Persist()
        {
            var domainEntities = this._dbContext.ChangeTracker
                .Entries<IAggregateRoot>()
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.GetEvents())
                .ToList();
            foreach (var @event in domainEvents)
            {
                var commandText = _eventPersistenceBuilder.Build();
                var command = new SqlCommand(commandText);
                var columns = _eventPersistenceBuilder.GetColumns();
                AddParametersToCommand(command, @event, columns);
                command.Connection = this._dbContext.Database.CurrentTransaction.GetDbTransaction().Connection as SqlConnection;
                command.Transaction = this._dbContext.Database.CurrentTransaction.GetDbTransaction() as SqlTransaction;
                await command.ExecuteNonQueryAsync();
            }
        }
        private void AddParametersToCommand(SqlCommand command, IDomainEvent @event, Dictionary<string, Func<IDomainEvent, object>> columns)
        {
            foreach (var column in columns)
            {
                var key = ToParameterName(column.Key);
                var value = column.Value.Invoke(@event);
                AddValueNullSafe(command, key, value);
            }
        }
        private string ToParameterName(string parameterKey)
        {
            return $"@{parameterKey.ToLower()}";
        }
        private void AddValueNullSafe(SqlCommand command, string key, object value)
        {
            command.Parameters.AddWithValue(key, value ?? DBNull.Value);
        }
    }
}
