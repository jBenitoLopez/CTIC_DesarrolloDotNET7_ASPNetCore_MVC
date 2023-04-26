using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ----
//app.MapGet("/", () => "Hello World!");

// ----
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello world Pipe!!!");
//});

// ----
//app.UseDeveloperExceptionPage();
//app.UseStaticFiles();
//app.UseAuthentication();
//app.MapDefaultControllerRoute();

// ----
app.Use(async (context, next) =>
{
    // Hacer algo antes de pasar el control al siguiente middleware:
    var watch = Stopwatch.StartNew();

    // Pasamos el control al siguiente middleware permitiendo que
    // la petición siga ascendiendo por el pipeline:
    await next(context);

    // Hacer algo cuando el proceso de los middlewares posteriores haya finalizado:
    Debug.WriteLine($"Execution time: {watch.ElapsedMilliseconds}ms");
});

app.Run();
