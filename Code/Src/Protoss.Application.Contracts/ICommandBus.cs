using System;
using System.Threading.Tasks;

namespace Protoss.Application.Contracts
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command) where T : class, ICommand;
    }
}
