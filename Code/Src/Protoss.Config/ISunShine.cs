using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Config
{
    public interface IProtoss
    {
        void Register(IDependencyRegister dependencyRegister);
    }
}
