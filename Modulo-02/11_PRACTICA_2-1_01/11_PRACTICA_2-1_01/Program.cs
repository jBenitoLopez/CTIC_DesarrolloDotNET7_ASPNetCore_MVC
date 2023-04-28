using _11_PRACTICA_2_1_01;

var builder = WebApplication.CreateBuilder(args);

#region 4. Inyección de dependencias
// ATENCION: esto se tiene que ejecutar antes del builder.Build()

builder.Services.AddTransient<IAdder, BasicCalculator>();
builder.Services.AddTransient<IOperationFormatter, OperationFormatter>();

#endregion 4. Inyección de dependencias


var app = builder.Build();

#region 4. Inyección de dependencias
app.Run(async (context) =>
{
    if (context.Request.Path == "/add")
    {
        int a = 0, b = 0;
        int.TryParse(context.Request.Query["a"], out a);
        int.TryParse(context.Request.Query["b"], out b);

        var adder = context.RequestServices.GetService<IAdder>();
        await context.Response.WriteAsync(adder.Add(a, b));
    }
    else
    {
        await context.Response.WriteAsync($"Try again!");
    }
});


#endregion 4. Inyección de dependencias

//app.MapGet("/", () => "Hello World!");

#region 1. Múltiples entornos
//app.Run(async (context) =>
//{
//    var msg = $"Current environment: {app.Environment.EnvironmentName}";
//    await context.Response.WriteAsync(msg);
//});


//if (app.Environment.IsDevelopment())
//{
//    app.Run(async (context) =>
//    {
//        await context.Response.WriteAsync("Development environment");
//    });
//}
//else
//{
//    app.Run(async (context) =>
//    {
//        await context.Response.WriteAsync("No development environment");
//    });
//}

#endregion 1. Múltiples entornos


#region 3. Middlewares
//app.Use(async (ctx, next) =>
//{
//    if (ctx.Request.Path  == "/hello")
//    {
//        // Procesa la petición y no permite la ejecución de otros middlewares
//        await ctx.Response.WriteAsync("Hello, user!");
//    }
//    else
//    {
//        // Pasa la petición al siguiente middleware
//        await next(ctx);
//    }
//});

//app.Use(async (ctx, next) =>
//{
//    if (ctx.Request.Path == "/hello-world")
//    {
//        // Procesa la petición y no permite la ejecución de middlewares posteriores
//        await ctx.Response.WriteAsync("Hello, world!");
//    }
//    else
//    {
//        // Pasa el control al siguiente middleware
//        await next(ctx);
//    }
//});
#endregion 3. Middlewares





//// Request Info middleware
//app.Run(async ctx =>
//{
//    await ctx.Response.WriteAsync($"Path requested: {ctx.Request.Path}");
//});



app.Run();
