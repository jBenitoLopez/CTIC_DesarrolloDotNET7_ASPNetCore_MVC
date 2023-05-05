using _19_3_1_DEMO_Constraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(opt =>
{
    opt.ConstraintMap.Add("is-albert", typeof(OnlyAlbertConstraint));
});
var app = builder.Build();

app.MapGet("/hello/{name:alpha:minlength(2)}", (string name) => $"Hello {name}!")
    .WithDisplayName("Hello entpoint");

app.MapGet("/only/{name:is-albert}", (string name) => $"Hello {name}!")
    .WithDisplayName("Hello entpoint");

app.Run();