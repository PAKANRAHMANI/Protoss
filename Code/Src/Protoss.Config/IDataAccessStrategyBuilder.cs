using Microsoft.EntityFrameworkCore;
using Protoss.Core;
using Protoss.DataAccess.NH;

namespace Protoss.Config
{
    public interface IDataAccessStrategyBuilder
    {
        IBuilder UseNH(SessionFactoryBuilder sessionFactory);
        IBuilder UseEF();
        ProtossBuilder WithModule(IProtoss Protoss);
    }
}