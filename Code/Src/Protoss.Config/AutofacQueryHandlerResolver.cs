using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Protoss.Query;

namespace Protoss.Config
{
    public class AutofacQueryHandlerResolver : IQueryHandlerResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacQueryHandlerResolver(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public IQueryHandler<TRequest, TResponse> ResolveHandlers<TRequest, TResponse>(TRequest request) where TRequest : IQuery
        {
            return _lifetimeScope.Resolve<IQueryHandler<TRequest, TResponse>>();
        }
    }
}
