using Saref.Data;
using Saref.Services.ShiftServices;
using Saref.Services.StadiumServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<StadiumService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyHeader();
    });
});
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("SafpContextDb");
//Asignar el contexto a la base de datos
builder.Services.AddSqlServer<ContextDB>(connectionString);

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
