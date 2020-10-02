﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Protoss.Query
{
    public interface IQueryBus
    {
        Task<TResponse> Execute<TRequest, TResponse>(TRequest request) where TRequest : IQuery;
    }
}
