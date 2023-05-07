using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication("MyApp")
    //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie("MyApp", (opt) =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromDays(1);
        opt.Cookie.HttpOnly = true;
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    });

var app = builder.Build();

// https://localhost:7066/login/Benito
app.MapGet("/login/{username}", async (HttpContext ctx, string username) =>
{
    var identity = new ClaimsIdentity("MyApp");
    identity.AddClaim(new Claim(ClaimTypes.Name, username));
    identity.AddClaim(new Claim(ClaimTypes.Role, "Administrador"));

    var principal = new ClaimsPrincipal(identity);
    await ctx.SignInAsync("MyApp", principal);
    return "Logged in!";
});

// https://localhost:7066/logout
app.MapGet("/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync("MyApp");
    return "Bye!!";
});

// https://localhost:7066/private
app.MapGet("/private", (HttpContext ctx) =>
{
    if (ctx.User.Identity.IsAuthenticated)
    {
        return "Secret content!";
    }
    return "Not allowed";
});



app.MapGet("/", () => "Hello World!");

app.Run();
