using Lab024.Handlers;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthorization();
builder.Services
    .AddAuthentication()
    .AddCookie(opt =>
    {
        opt.LoginPath = "/login";
    });

// Configuración del pipeline
var app = builder.Build();

app.UseSession();

app.MapGet("/", () => "Go to /home to start");

app.MapGet("/login", LoginHandlers.GetLoginPageAsync);
app.MapPost("/login", LoginHandlers.DoLoginAsync);
app.MapGet("/logout", LoginHandlers.DoLogoutAsync);
app.MapGet("/home", HomeHandlers.GetHomePageAsync)
            .RequireAuthorization();

app.Run();
