var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");




#region one
//app.UseRouting(); // es añadido automaticamente por la API
// middleware
//app.Use(async (ctx, next) => 
//{
//    var selectedEndpoint = ctx.GetEndpoint();

//    if (selectedEndpoint?.DisplayName == "Hello endpoint!")
//    {
//        var name = ctx.GetRouteValue("name")?.ToString();
//        if("Jon".Equals(name, StringComparison.CurrentCultureIgnoreCase))
//        {
//            ctx.Request.RouteValues["name"] = "John";
//        }
//    }
//    await next(ctx);
//});

// UseEndpoints es añadido automaticamente por la API
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/hello/{name}", (string name) =>
//    {
//        return $"Hello {name}!";
//    }).WithDisplayName("Hello endpoint!");
//});
#endregion one

#region two
    // "one" es equivalente a esto
    app.MapGet("/hello/{name}", (string name) =>
    {
        return $"Hello {name}!";
    }).WithDisplayName("Hello endpoint!");
#endregion two

app.Run();
