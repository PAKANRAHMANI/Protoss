using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Protoss.Application.Contracts;
using Protoss.Core;
using Protoss.Domain;
using Protoss.Query;

namespace Protoss.Config
{
    public class DependencyRegister : IDependencyRegister
    {
        private readonly ContainerBuilder _container;

        public DependencyRegister(ContainerBuilder container)
        {
            _container = container;
        }
        public void RegisterCommandHandlers(Assembly assembly)
        {
            _container.RegisterAssemblyTypes(assembly)
                .As(type => type.GetInterfaces()
                .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
                .InstancePerLifetimeScope();
        }

        public void RegisterQueryHandlers(Assembly assembly)
        {
            _container.RegisterAssemblyTypes(assembly)
                .Where(type => typeof(IQueryHandler<,>).IsAssignableFrom(type))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        public void RegisterRepositories(Assembly assembly)
        {
            _container.RegisterAssemblyTypes(assembly)
                .Where(type => typeof(IRepository).IsAssignableFrom(type))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        public void RegisterFacades(Assembly assembly)
        {
            _container.RegisterAssemblyTypes(assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InstancePerLifetimeScope();
        }

        public void RegisterDomainServices(Assembly assembly)
        {
            _container.RegisterAssemblyTypes(assembly)
                .Where(a => typeof(IDomainService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
