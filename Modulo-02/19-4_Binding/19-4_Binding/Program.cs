using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/test/{id?}", TestHandlers.Test);

// Obtener array de tipos básicos
// GET  /friends?id=1&id=2&id=3 -> Ids: 1, 2, 3
app.MapGet("/friends-id", (int[] id) => $"Ids: {string.Join(", ", id)}");

// Obtener array de strings
// GET /friends?email=one@server.com&email=two@server.com -> Emails: one@server.com, two@server.com
app.MapGet("/friends-email", (string[] email) => $"Emails: {string.Join(", ", email)}");

// GET /add/1?b=2
// Resultado: 3
app.MapGet("/add/{a}", (int a, int b) => a + b);

// GET /add?a=1&b=2
// Resultado: 3
app.MapGet("/add", (int a, int b) => a + b);


// GET /add/1?a=2&b=3
// Resultado: 5
app.MapGet("/add/{a}", ([FromQuery] int a, int b) => a + b);

app.MapGet("/", ([FromHeader(Name = "user-agent")] string userAgent)
        => "Your user agent: " + userAgent
);

// GET /test-header HTTP/1.1
// x-data: data1
// x-data: data2
// -------------
// Result:
// X-Data: data1, data2
app.MapGet("/test-header", ([FromHeader(Name = "x-data")] string[] data) => $"X-Data: {string.Join(", ", data)}");

//app.MapPut("/friends/{id}", async (int id, Friend friend) => {
//    var repo = ctx.RequestServices.GetService<IFriendRepo>();
//    await repo.UpdateAsync(id, friend);
//});

app.MapPost("/test", ([FromBody] int i) => "Received: " + i);


//// En lugar de:
//app.MapPut("/friends/{id}", async (int id, Friend friend, HttpContext ctx) => {
//    var repo = ctx.RequestServices.GetRequiredService<IFriendRepo>();
//    await repo.UpdateAsync(id, friend);
//});
//// Podemos usar:
//app.MapPut("/friends/{id}", async (int id, Friend friend, IFriendRepo repo) => {
//    await repo.UpdateAsync(id, friend);
//});

app.MapPost("/{userName}/avatar", async (string userName, IFormFile file) =>
{
    var path = Path.Combine(app.Environment.WebRootPath, $"users/{userName}/profile.jpg");
    using var stream = System.IO.File.OpenWrite(path);
    await file.CopyToAsync(stream);
});

app.MapPost("/{userName}/files", async (string userName, IFormFileCollection files) =>
{
    foreach (var file in files)
    {
        var path = Path.Combine(app.Environment.WebRootPath, $"users/{userName}/files/{file.FileName}");
        using var stream = System.IO.File.OpenWrite(path);
        await file.CopyToAsync(stream);
    }
});

//app.MapGet("/products", ([FromHeader] string host, string? term, int? categoryId, int? page, int? pageSize, [FromServices] CatalogServices catalog) =>
//{
//    page ??= 1;
//    pageSize ??= 20;
//    var products = catalog.Search(host, term, categoryId, page.Value, pageSize.Value);
//    return products.Any() ? Results.Ok(products) : Results.NotFound();
//});


//record struct CatalogSearchArgs(
//    [FromHeader] string Host,
//    string? Term,
//    int? CategoryId,
//    int Page = 1,
//    int PageSize = 20
//);
//app.MapGet("/admin/products", ([AsParameters] CatalogSearchArgs args, CatalogServices svc) =>
//{
//    var products = svc.Search(
//        args.Host,
//        args.Term,
//        args.CategoryId,
//        args.Page,
//        args.PageSize
//    );
//    return products.Any() ? Results.Ok(products) : Results.NotFound();
//})
//.RequireAuthorization(policyNames: "admin");



app.Run();


// En otra parte del código:
public class TestHandlers
{
    public static string Test(int id = 99) => "Id: " + id;
}