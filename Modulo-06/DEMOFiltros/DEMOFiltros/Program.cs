using DEMOFiltros.Extensions.Filters;
using DEMOFiltros.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddControllersWithViews(config =>
{
    config.Filters.Add(new AuthorizeFilter());
    config.Filters.Add(new HandledByMvcAttribute());
});

builder.Services.AddAuthentication()
    .AddCookie(opt =>
    {
        opt.AccessDeniedPath = "/account/login";
        opt.LoginPath = "/account/login";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FourCharacters",
        builder =>
        {
            builder.RequireAssertion(cond => cond.User.Identity?.IsAuthenticated == true && cond.User.Identity?.Name?.Length == 4);
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

