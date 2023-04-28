using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Pipeline configuration
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.UseWelcomePage("/hello");

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello, world!");
//});



//app.Run(async (context) =>
//{
//    if (context.Request.Path == "/boom")
//        throw new InvalidOperationException("Invalid operation");

//    await context.Response.WriteAsync("Hello, world!");
//});

#region exception


// ¡Importante! Incluir el siguiente middleware es necesario 
// para que la aplicación pueda retornar archivos estáticos:
app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/friendlyError500.html");
}

app.Run(async (context) =>
{
    if (context.Request.Path == "/boom")
    {
        throw new InvalidOperationException("Boom!!");
    }

    await context.Response.WriteAsync("Hello, world!");
});
#endregion exception

#region status-code
app.UseStatusCodePagesWithReExecute("/error404");
app.Use(async (ctx, next) =>
{
    if (ctx.Request.Path == "/error404")
    {
        var feature = ctx.Features.Get<IStatusCodeReExecuteFeature>();
        var path = feature.OriginalPath;
        await ctx.Response.WriteAsync($"Path not found: {path}");
    }
    else
    {
        await next(ctx);
    }
});
#endregion status-code


app.Run();
