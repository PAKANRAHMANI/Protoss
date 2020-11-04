using Microsoft.EntityFrameworkCore;
using Protoss.Core;
using Protoss.DataAccess.NH;

namespace Protoss.Config
{
    public interface IDataAccessStrategyBuilder
    {
        IBuilder UseNH(SessionFactoryBuilder sessionFactory);
        IBuilder UseEF(DomainEventPersistenceBuilder domainEventPersistenceBuilder);
        ProtossBuilder WithModule(IProtoss Protoss);
    }
}