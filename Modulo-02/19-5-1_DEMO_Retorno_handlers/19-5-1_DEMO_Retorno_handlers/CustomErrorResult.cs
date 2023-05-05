namespace _19_5_1_DEMO_Retorno_handlers
{
    public class CustomErrorResult : IResult
    {
        private readonly string text;

        public CustomErrorResult(string text)
        {
            this.text = text;
        }
        public async Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 999;
            await httpContext.Response.WriteAsync("Error terrible: " + text);
        }
    }

    public static class CustomResultsExtension
    {
        public static IResult CustomError(this IResultExtensions result, string text)
        {
            return new CustomErrorResult(text);
        }
    }
}
