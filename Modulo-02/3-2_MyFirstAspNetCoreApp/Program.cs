var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.MapGet("/", (HttpContext context) =>
{
    var name = (string)context.Request.Query["name"] ?? "unknow user";
    return $"Hello, {name}";
});

app.MapGet("/time", () =>
{
    return DateTime.Now.ToString("HH:mm:ss tt");
});

app.MapGet("/sum", (HttpContext context) =>
{
    var a = Int32.Parse((string)context.Request.Query["a"] ?? "0");
    var b = Int32.Parse((string)context.Request.Query["b"] ?? "0");

    return a + b;
});

app.Run();
