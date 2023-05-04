using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab022.Middlewares.CustomErrorPages;

namespace Microsoft.AspNetCore.Builder
{
    public static class CustomErrorPagesExtensions
    {
        public static IApplicationBuilder UseCustomErrorPages(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomErrorPagesMiddleware>();
        }
    }
}
