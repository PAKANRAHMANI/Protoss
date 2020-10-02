using Autofac;

namespace Protoss.Config
{
    public interface IBuilder
    {
        ContainerBuilder Build();
    }
}