namespace _19_5_APIs_sencillas
{

    // Implementamos la clase:
    public class TeapotResult : IResult
    {
        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = 418;
            return Task.CompletedTask;
        }
    }
    // Y un extensor para facilitar su uso:
    public static class CustomResultsExtensions
    {
        public static IResult TeaPot(this IResultExtensions results)
        {
            return new TeapotResult();
        }
    }

}
