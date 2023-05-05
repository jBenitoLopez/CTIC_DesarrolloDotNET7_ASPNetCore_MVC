namespace _19_3_1_DEMO_Routing_Constraints2
{
    public class OnlyAlbertConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContext? httpContext, 
            IRouter? route, string routeKey, 
            RouteValueDictionary values,
            RouteDirection routeDirection
            )
        {
            var name = values[routeKey]?.ToString();
            return (name != null && name.StartsWith("albert", StringComparison.CurrentCultureIgnoreCase));

        }
    }
}
