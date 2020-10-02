using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Protoss.Config
{
    public interface IDependencyRegister
    {
        void RegisterCommandHandlers(Assembly assembly);
        void RegisterRepositories(Assembly assembly);
        void RegisterFacades(Assembly assembly);
        void RegisterDomainServices(Assembly assembly);
        void RegisterQueryHandlers(Assembly assembly);
    }
}
