using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Saref.Data;
using Saref.Models.Client;
using Saref.Services.ClientServices;
using Saref.Services.JwtServices;
using Saref.Services.ProductServices.ShoesService;
using Saref.Services.ProductServices.TshirtService;
using Saref.Services.ShiftServices;
using Saref.Services.StadiumServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configurePoli =>
    { configurePoli.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
});

builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
builder.Services.AddScoped<StadiumService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<TshirtService>();
builder.Services.AddScoped<ShoesService>();
builder.Services.AddScoped<JwtTokenService>();
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("ContextDataBase");
//Asignar el contexto a la base de datos
builder.Services.AddDbContext<ContextDB>(options => options.UseSqlite(connectionString));
builder.Services.AddIdentityApiEndpoints<Client>().AddEntityFrameworkStores<ContextDB>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => { options.SaveToken = true; options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { ValidateIssuer = true, ValidateAudience = true, ValidateLifetime = true, ValidateIssuerSigningKey = true, ValidIssuer = builder.Configuration["Jwt:Issuer"], ValidAudience = builder.Configuration["Jwt:Audience"], IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])) }; });
var app = builder.Build();
app.UseCors();
app.UseAuthentication();
app.MapControllers();

app.Run();
