using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Protoss.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCqrsConvention(this MvcOptions options)
        {
            options.Conventions.Add(new CqrsConvention());
        }
    }
}
