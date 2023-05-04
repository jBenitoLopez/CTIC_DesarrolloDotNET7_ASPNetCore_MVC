using System.Diagnostics;
using System.Threading.Tasks;
using Lab022.Middlewares;
using Lab022.Middlewares.Calculator;
using Lab022.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public static class CalculatorExtensions
    {
        public static IApplicationBuilder UseCalculator(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<CalculatorMiddleware>(path);
        }
    }
}