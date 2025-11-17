using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Client;
using Saref.Services.ClientServices;
using Saref.Services.ShiftServices;
using Saref.Services.StadiumServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
builder.Services.AddScoped<StadiumService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:8081", "http://localhost:8081").AllowAnyMethod().AllowAnyHeader();
    });
});
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("ContextDataBase");
//Asignar el contexto a la base de datos
//builder.Services.AddSqlite<ContextDB>(connectionString);
builder.Services.AddDbContext<ContextDB>(options => options.UseSqlite(connectionString));
builder.Services.AddIdentityApiEndpoints<Client>().AddEntityFrameworkStores<ContextDB>();
var app = builder.Build();
//app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
