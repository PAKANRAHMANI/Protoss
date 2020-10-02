using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Query
{
    public interface IQueryHandlerResolver
    {
        IQueryHandler<TRequest,TResponse> ResolveHandlers<TRequest, TResponse>(TRequest request) where TRequest : IQuery;
    }
}
