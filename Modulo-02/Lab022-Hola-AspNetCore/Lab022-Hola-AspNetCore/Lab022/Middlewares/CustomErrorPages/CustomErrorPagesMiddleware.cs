using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lab022.Middlewares.CustomErrorPages
{
    public class CustomErrorPagesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomErrorPagesMiddleware(RequestDelegate next, ILogger<CustomErrorPagesMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/error/show/500")
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionHandlerFeature.Error;
                var exceptionName = exception.GetType().Name;
                await SendHtmlPage(context,
                    statusCode: 500,
                    title: $"Server error",
                    description: $"We have detected a server error: {exceptionName}"
                );
                _logger.LogError($"Error {exceptionName}: {exception.Message}");
            }
            else if (context.Request.Path == "/error/show/404")
            {
                var statusCodeFeature = context.Features.Get<IStatusCodeReExecuteFeature>();
                var path = statusCodeFeature.OriginalPath;
                await SendHtmlPage(context,
                    statusCode: 404,
                    title: "Not found",
                    description: $"No content found at '{path}'"
                );
                _logger.LogError($"Error 404 for path '{path}'");
            }
            else
            {
                await _next(context);
            }
        }

        private async Task SendHtmlPage(HttpContext context, int statusCode, string title, string description)
        {
            var content = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset='utf-8' />
                        <title>{title}</title>
                        <link href='/styles/calculator.css' rel='stylesheet' />
                    </head>
                    <body>
                        <h1>
                            <span class='statusCode'>{statusCode}</span> {title}
                        </h1>
                        <p>{description}.</p>
                        <p><a href='javascript:history.back()'>Go back</a>.</p>
                    </body>
                    </html>
            ";
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(content);
        }
    }
}
