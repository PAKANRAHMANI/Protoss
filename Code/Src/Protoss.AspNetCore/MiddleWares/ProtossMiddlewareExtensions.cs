using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Protoss.AspNetCore.MiddleWares
{
    public static class ProtossMiddlewareExtensions
    {
        public static IApplicationBuilder UseProtossExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
