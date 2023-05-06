using _20_PRACTICA_2_3.Constraints;
using _20_PRACTICA_2_3.Handlers;
using _20_PRACTICA_2_3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(opt =>
{
    opt.ConstraintMap.Add("valid-operation", typeof(ValidOperationConstraint));
});
builder.Services.AddTransient<ICalculatorServices, CalculatorServices>();
builder.Services.AddTransient<ICalculationEngine, CalculationEngine>();

var app = builder.Build();

app.MapGet("/", () => "Welcome to the calculator!");

//var calculatorApi = app.MapGroup("/api/calculator")
//    .RequireAuthorization()
//    .RequireCors("default");
//calculatorApi.MapGet("add/{a}/{b}", (int a, int b) => a + b);
//calculatorApi.MapGet("sub/{a}/{b}", (int a, int b) => a - b);
//calculatorApi.MapGet("mul/{a}/{b}", (int a, int b) => a * b);

// https://localhost:7249/calculator/add/5/19
app.MapCalculator("/calculator/{operation:valid-operation}/{a:int}/{b:int}");
app.Run();
