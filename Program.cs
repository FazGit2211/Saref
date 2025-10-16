using Saref.Data;
using Saref.Services.ShiftServices;
using Saref.Services.StadiumServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<StadiumService>();
builder.Services.AddScoped<ShiftService>();
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("SafpContextDb");
//Asignar el contexto a la base de datos
builder.Services.AddSqlServer<ContextDB>(connectionString);

var app = builder.Build();

app.MapControllers();

app.Run();
