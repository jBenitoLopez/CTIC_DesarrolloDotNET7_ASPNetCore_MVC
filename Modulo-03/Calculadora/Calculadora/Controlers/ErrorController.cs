using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controlers
{
    public class ErrorController : Controller
    {
        private readonly ILogger logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;

        }
        public IActionResult Show(int id)
        {
            var html = string.Empty;
            if (id == 500)
            {
                var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionHandlerFeature.Error;
                var exceptionName = exception.GetType().Name;

                logger.LogError($"Exception thrown '{exceptionName}: {exception.Message}'");

                html = GetHtmlPage(
                    statusCode: 500,
                    title: $"Server error",
                    description: $"We have detected a server error {exceptionName}"
                );
            }
            else if (id == 404)
            {
                var statusCodeFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                var path = statusCodeFeature.OriginalPath;

                logger.LogError($"Error 404 for path '{path}'");

                html = GetHtmlPage(
                    statusCode: 404,
                    title: "Not found",
                    description: $"No content found at '{path}'"
                );
            }

            return Content(html, contentType: "text/html");
        }

        private string GetHtmlPage(int statusCode, string title, string description)
        {
            return $@"
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
        }
    }
}
