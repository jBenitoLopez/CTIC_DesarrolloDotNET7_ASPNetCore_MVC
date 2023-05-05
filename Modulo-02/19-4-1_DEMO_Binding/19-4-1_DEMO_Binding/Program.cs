using _19_4_1_DEMO_Binding;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICalculatorServices, CalculatorServices>();

var app = builder.Build();

//app.MapGet("/add/{a}/{b}", (int a, int b) => a + b);
//https://localhost:7092/add/5/11
app.MapGet("/add/{a}/{b}", CalculatorHandlers.Add);
//https://localhost:7092/sub/15/5
app.MapGet("/sub/{a}/{b?}", CalculatorHandlers.Sub);

// https://localhost:7092/mul/?a=5&b=3
app.MapGet("/mul", CalculatorHandlers.Mul);
// https://localhost:7092/multiply/5/4
app.MapGet("/multiply/{a}/{b}", (int a, int b, ICalculatorServices calculator) => calculator.Multiply(a,b));


app.MapGet("/concat/{a}/{b}", (string a, string b) => a + b);

// POST: https://localhost:7092/friends -- Body_JSON: {"name": "Pepito","age": 50}
app.MapPost("/friends", (Friend friend) => $"Recibido: {friend.Name}");


app.MapGet("/", 
    (
        [FromHeader(Name = "user-agent")] string userAgent, 
        [FromHeader(Name = "accept-language")] string language
    ) 
        => $"Language: {language}, user agent: {userAgent}" 
);

app.Run();
