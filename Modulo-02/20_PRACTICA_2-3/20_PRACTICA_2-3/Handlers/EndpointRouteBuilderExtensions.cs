namespace _20_PRACTICA_2_3.Handlers
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapCalculator(this IEndpointRouteBuilder endpoints, string routePattern)
        {
            { return endpoints.MapGet(routePattern, CalculatorHandler.Calculate); }
        }
    }
}
