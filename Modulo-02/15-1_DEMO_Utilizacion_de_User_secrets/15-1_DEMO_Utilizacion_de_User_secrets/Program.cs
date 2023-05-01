var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async ctx =>
{
    await ctx.Response.WriteAsync($"Connection string: {app.Configuration["ConnectionString"]}");
});

app.Run();
