﻿using System.Data.SqlClient;
using Autofac;
using NHibernate;
using Protoss.Application;
using Protoss.Application.Contracts;
using Protoss.Core;
using Protoss.Core.Clock;
using Protoss.Core.Events;
using Protoss.DataAccess.EF;
using Protoss.DataAccess.NH;
using Protoss.Logging.SeriLog;

namespace Protoss.Config
{
    public class ProtossBuilder : IDataAccessStrategyBuilder, IBuilder
    {
        private readonly ContainerBuilder _container;
        private ISessionFactory _factory;

        private ProtossBuilder(ContainerBuilder container)
        {
            this._container = container;
        }
        public static IDataAccessStrategyBuilder Setup(ContainerBuilder container) => new ProtossBuilder(container);
        public IBuilder UseNH(SessionFactoryBuilder sessionFactory)
        {
            _container.Register(a => CreateSession(sessionFactory)).OnRelease(a => a.Close()).InstancePerLifetimeScope();
            _container.RegisterType<NhUnitOfWork>().As<IUnitOfWork>();
            return this;
        }

        public IBuilder UseEF()
        {
            _container.RegisterType<EfUnitOfWork>().As<IUnitOfWork>();
            return this;
        }
        public ProtossBuilder WithSeriLog(Serilog.ILogger logger)
        {
            var adapter = new SeriLogAdapter(logger);
            _container.RegisterInstance<Core.Logging.ILogger>(adapter).SingleInstance();
            _container.RegisterDecorator(typeof(LoggingCommandHandlerDecorator<>), typeof(ICommandHandler<>));
            return this;
        }
        
        //TODO:aval faght with module neshon dade beshe badesh ef/nh/log/exception handling
        public ProtossBuilder WithModule(IProtoss Protoss)
        {
            RegisterDependency(Protoss);
            return this;
        }
        public ContainerBuilder Build()
        {
            _container.RegisterType<SystemDateTime>().As<IDateTime>().SingleInstance();
            _container.RegisterType<EventAggregator>().As<IEventAggregator>().InstancePerLifetimeScope();
            _container.RegisterType<EventListener>().As<IEventListener>().InstancePerLifetimeScope();
            _container.RegisterType<EventPublisher>().As<IEventPublisher>().InstancePerLifetimeScope();
            _container.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
            _container.RegisterType<CommandHandlerResolver>().As<ICommandHandlerResolver>().InstancePerLifetimeScope();
            _container.RegisterGenericDecorator(typeof(TransactionalCommandHandlerDecorator<>), typeof(ICommandHandler<>));
            return _container;
        }
        private ISession CreateSession(SessionFactoryBuilder sessionFactory)
        {
            _factory = sessionFactory.Build();
            var builder = _factory.WithOptions();
            var connection = new SqlConnection(sessionFactory.ConnectionString);
            connection.Open();
            return builder.Connection(connection).OpenSession();
        }
        private void RegisterDependency(IProtoss module)
        {
             module.Register(new DependencyRegister(_container));
        }
    }
}