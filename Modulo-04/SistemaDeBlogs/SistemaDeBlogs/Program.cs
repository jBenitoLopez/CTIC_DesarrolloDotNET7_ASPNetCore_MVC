using SistemaDeBlogs.Models.Services;
using SistemaDeBlogs.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBlogServices, BlogServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// Ruta específica para la nueva acción
app.MapControllerRoute(
    name: "archive",
    pattern: "blog/archive/{year}/{month}",
    defaults: new { controller = "Blog", action = "Archive" }
);

// Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");


app.Run();
