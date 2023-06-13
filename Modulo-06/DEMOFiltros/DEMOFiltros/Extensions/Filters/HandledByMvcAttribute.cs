using Microsoft.AspNetCore.Mvc.Filters;

namespace DEMOFiltros.Extensions.Filters
{
    public class HandledByMvcAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Handled-By", "ASP.NET Core MVC");
            base.OnResultExecuting(context);
        }
    }
}