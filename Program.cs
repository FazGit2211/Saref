using Microsoft.AspNetCore.Identity;
using Saref.Data;
using Saref.Models.User;
using Saref.Services.ClientServices;
using Saref.Services.ShiftServices;
using Saref.Services.StadiumServices;
using Saref.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<StadiumService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<UserService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:8081").AllowAnyMethod().AllowAnyHeader();
    });
});
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("ContextDataBase");
//Asignar el contexto a la base de datos
builder.Services.AddSqlite<ContextDB>(connectionString);

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
