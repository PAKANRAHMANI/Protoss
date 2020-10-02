using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Protoss.Core.Exceptions;

namespace Protoss.AspNetCore.MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                await HandleException(context,exception);
            }
        }

        private async Task HandleException(HttpContext context,Exception exception)
        {
            if (exception is ProtossException ProtossException)
                await HandleBusinessException(context, ProtossException);
            else await UnhandledException(context, exception);
        }

        private async Task HandleBusinessException(HttpContext context, ProtossException ProtossException)
        {
            var error = ExceptionDetails.Create(ProtossException.ExceptionMessage, ProtossException.Code);
            await WriteExceptionToResponse(context, error);
        }

        private async Task WriteExceptionToResponse(HttpContext context,ExceptionDetails error)
        {
            context.Response.StatusCode = (int)error.Code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
        private async Task UnhandledException(HttpContext httpContext, Exception exception)
        {
            var error =  ExceptionDetails.Create(exception.Message, -1000);
            await WriteExceptionToResponse(httpContext, error);
        }
    }
}
