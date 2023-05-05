using _19_5_APIs_sencillas;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//app.MapGet("/friends", async (IFriendsRepo repo) => {
//    var friends = await repo.GetFriendsAsync();
//    return friends;
//});

//app.MapPost("/invoices", async (IInvoiceServices services, Invoice invoice) =>
//{
//    if (invoice == null)
//    {
//        return Results.BadRequest(); // HTTP 400
//    }
//    await services.CreateAsync(invoice);
//    // Retornamos un HTTP 200 con el objeto recibido (JSON)
//    return Results.Ok(invoice);
//});

// POST: https://localhost:7197/coffe
app.MapPost("/coffe", () =>
{
    return Results.Extensions.TeaPot();
});

//app.MapGet("/test/{i}", (int i) =>
//{
//    var mod = i % 3;
//    return mod switch
//    {
//        0 => Results.Ok(new Friend("John", "john@server.com")),
//        1 => Results.Ok(new Invoice(1, 100.25)),
//        _ => Results.BadRequest(),
//    };
//});

//app.MapGet("/test/{i}", Results<Ok<Friend>, Ok<Invoice>, BadRequest> (int i) =>
//{
//    var mod = i % 3;
//    return mod switch
//    {
//        0 => TypedResults.Ok(new Friend("John", "john@server.com")),
//        1 => TypedResults.Ok(new Invoice(1, 100.25)),
//        _ => TypedResults.BadRequest(),
//    };
//});


app.Run();
