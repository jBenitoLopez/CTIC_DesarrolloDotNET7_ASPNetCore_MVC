using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

#region 3
builder.Services.AddDirectoryBrowser();
#endregion 3

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

#region 1
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseDirectoryBrowser();
app.UseFileServer(enableDirectoryBrowsing: true);
// Otros middlewares
#endregion 1


#region 2
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers
           .Add("X-Copyright", "Copyright (C) CampusMVP");
    }
});

#endregion 2

#region 3
app.UseDirectoryBrowser();
#endregion 3

#region 4
#endregion 4

app.Run();
