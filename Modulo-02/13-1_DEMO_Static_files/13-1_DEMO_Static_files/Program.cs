var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDirectoryBrowser();

var app = builder.Build();


//app.UseDefaultFiles(new DefaultFilesOptions
//{
//    DefaultFileNames = new[] {"second.html"}
//});
//app.UseStaticFiles();
//app.UseDirectoryBrowser();

app.UseFileServer(new FileServerOptions
{
    RequestPath = "/static",
    EnableDirectoryBrowsing = true,
    EnableDefaultFiles = true,
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Run();
