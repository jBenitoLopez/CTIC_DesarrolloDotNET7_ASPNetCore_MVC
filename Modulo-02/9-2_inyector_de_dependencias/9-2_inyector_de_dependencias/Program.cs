using Microsoft.AspNetCore.Hosting.Server;

var builder = WebApplication.CreateBuilder(args);
// ----
//builder.Services.AddControllersWithViews();

// ----
//// Registra los servicios de Entity Framework Core para SQLite
//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseSqlite(connectionString: "...")
//);
//
//// Registra los servicios de autenticaci�n basada en cookies
//builder.Services.AddAuthentication().AddCookie();
//// Registra los servicios del framework MVC
//builder.Services.AddControllersWithViews();
// ----
//// Cuando alg�n componente requiera una instancia de ICalculator,
//// el contenedor retornar� siempre un nuevo objeto MyCalculator:
//builder.Services.AddTransient<ICalculator, MyCalculator>();
////
//// Cuando en el contexto de una petici�n los componentes requieran instancias de
//// IDataConnection, el contenedor retornar� siempre el mismo MyDataConnection,
//// que ser� liberado al finalizar su proceso:
//builder.Services.AddScoped<IDataConnection, MyDataConnection>();
////
//// Se crear� una instancia de MyRemoteClient cuando se solicite un IRemoteClient
//// por primera vez, y se reutilizar� en todas las peticiones posteriores:
//builder.Services.AddSingleton<IRemoteClient, MyRemoteClient>();

// ----
//// Usa la factor�a para crear la instancia de ICalculator:
//builder.Services.AddTransient<ICalculator>(svc => new MyCalculator());
//var singleton = new MySingleton()
//{
//// TODO: inicializar aqu� las propiedades del objeto singleton
//};
//builder.Services.AddSingleton(singleton);

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
// ----
app.MapGet("/", () =>
    app.Environment.IsDevelopment()
        ? "Hello developer!"
        : "Hello user!"
);

// ----
if (app.Environment.IsEnvironment("Home"))
{
    app.MapGet("/home", () => "This is only available for Home environment");
}

// ----
//if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddSingleton<ISender, FakeSender>();
//}
//else
//{
//    builder.Services.AddSingleton<ISender, EmailSender>();
//}



// ----
var currentEnvironmentName = builder.Environment.EnvironmentName;
// O bien:
// var app = builder.Build();
// var currentEnvironmentName = app.Environment.EnvironmentName;
app.MapGet("/environment", () => app.Environment.EnvironmentName);

//app.MapDefaultControllerRoute();



app.Run();
