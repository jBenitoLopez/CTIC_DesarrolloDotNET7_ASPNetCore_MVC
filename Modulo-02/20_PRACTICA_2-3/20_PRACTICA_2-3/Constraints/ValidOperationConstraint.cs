namespace _20_PRACTICA_2_3.Constraints
{
    public class ValidOperationConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var operation = values[routeKey]?.ToString()?.ToLower();

            if (operation == "div" && int.TryParse(values["b"]?.ToString(), out var b) && b == 0)
            {
                return false;
            }

            return operation == "add" || operation == "sub" || operation == "mul" || operation == "div";
        }
    }
}
