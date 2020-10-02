using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Protoss.Core
{
    public interface IUnitOfWork
    {
        Task Begin();
        Task Commit();
        Task RollBack();
    }
}
