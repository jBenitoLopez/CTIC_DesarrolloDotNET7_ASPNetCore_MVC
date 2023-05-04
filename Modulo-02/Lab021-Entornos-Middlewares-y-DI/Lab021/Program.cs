using Lab021.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IAdder, BasicCalculator>();
builder.Services.AddTransient<IOperationFormatter, OperationFormatter>();
var app = builder.Build();

// Configure pipeline

app.Run(async (context) =>
{
    if (context.Request.Path == "/add")
    {
        int.TryParse(context.Request.Query["a"], out int a);
        int.TryParse(context.Request.Query["b"], out int b);

        var adder = context.RequestServices.GetService<IAdder>();
        if (adder == null)
        {
            await context.Response.WriteAsync("Don't forget to register services!");
        }
        else
        {
            await context.Response.WriteAsync(adder.Add(a, b));
        }
    }
    else
    {
        await context.Response.WriteAsync($"Try again!");
    }
});

app.Run();
