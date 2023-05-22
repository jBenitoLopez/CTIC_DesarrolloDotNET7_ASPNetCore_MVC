using _07_DEMO_anhadiendo_funcionalidades.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBlogServices, BlogServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "slug", // Nombre único de la ruta
//    pattern: "blog/{slug}",
//    defaults: new { controller = "Slug", action = "Archive" });

app.MapControllerRoute(
    name: "archive", // Nombre único de la ruta
    pattern: "blog/archive/{year}/{month}",
    defaults: new {controller="Blog", action="Archive"} );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
