using System;
using System.Linq;
using System.Reflection;
using Autofac;
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

        public void RegisterScoped<TService>(Func<TService> factory, Action<TService> release = null)
        {
            var registration = _container.Register(a => factory.Invoke()).InstancePerLifetimeScope();
            if (release != null)
                registration.OnRelease(release);
        }

        public void RegisterScoped<TService>(Type implementationType)
        {
            _container.RegisterType(implementationType).As<TService>().InstancePerLifetimeScope();
        }

        public void RegisterScoped(Type implementationType)
        {
            _container.RegisterType(implementationType).InstancePerLifetimeScope();
        }

        public void RegisterScoped<TService, TImplementation>() where TImplementation : TService
        {
            _container.RegisterType<TImplementation>().As<TService>().InstancePerLifetimeScope();
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _container.RegisterType<TImplementation>().As<TService>().SingleInstance();
        }

        public void RegisterSingleton<TService, TInstance>(TInstance instance) where TService : class where TInstance : TService
        {
            _container.RegisterInstance<TService>(instance).SingleInstance();
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _container.RegisterType<TImplementation>().As<TService>().InstancePerDependency();
        }

        public void RegisterDecorator<TService, TDecorator>() where TDecorator : TService
        {
            _container.RegisterDecorator<TDecorator, TService>();
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
