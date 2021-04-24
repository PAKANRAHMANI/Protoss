using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Protoss.Utility.Middlewares;

namespace Protoss.Utility
{
    public static class ImagesMiddlewareExtensions
    {
        public static void UseImages(this IApplicationBuilder app)
        {
            app.UseMiddleware<ImagesMiddleware>();
        }
    }
}
