namespace _26_PRACTICA_2_4.Handlers
{
    public class PageUtils
    {
        public static async Task SendPageAsync(HttpContext context, string title, string body)
        {
            var content = $@"
                                <!DOCTYPE html>
                                <html>
                                <head>
                                    <meta charset='utf-8' />
                                    <title>{title}</title>
                                    <link href='/styles/site.css' rel='stylesheet' />
                                </head>
                                <body>
                                    {body}
                                </body>
                                </html>
                            ";

            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(content);
        }
    }
}
