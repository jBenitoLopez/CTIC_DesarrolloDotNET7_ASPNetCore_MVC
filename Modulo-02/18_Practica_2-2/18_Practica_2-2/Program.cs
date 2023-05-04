//using _18_Practica_2_2.Middlewares.CustomErrorPage;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/error/show/{0}");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/show/500");
    //app.UseCustomErrorPages();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
