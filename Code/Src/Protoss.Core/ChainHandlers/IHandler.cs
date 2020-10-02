using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Protoss.Core.ChainHandlers
{
    public interface IHandler<T>
    {
        Task Handle(T request);
        void SetNext(IHandler<T> handler);
    }
}
