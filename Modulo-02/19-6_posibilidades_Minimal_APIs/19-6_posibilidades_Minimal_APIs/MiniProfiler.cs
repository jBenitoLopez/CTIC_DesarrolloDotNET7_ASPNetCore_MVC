namespace _19_6_posibilidades_Minimal_APIs
{
    public class MiniProfiler : IEndpointFilter
    {
        private readonly ILogger<MiniProfiler> _logger;

        public MiniProfiler(ILogger<MiniProfiler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = await next(context);
            _logger.LogInformation("Elapsed ticks: " + sw.ElapsedTicks);
            return result;
        }
    }

}
