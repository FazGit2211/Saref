using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Saref.Data;
using Saref.Exceptions;
using Saref.Models.Client;
using Saref.Services.ClientServices;
using Saref.Services.JwtServices;
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

builder.Services.AddControllers().ConfigureApiBehaviorOptions(option => option.SuppressModelStateInvalidFilter = true).AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
builder.Services.AddScoped<StadiumService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddProblemDetails();
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("ContextDataBase");
//Asignar el contexto a la base de datos
builder.Services.AddDbContext<ContextDB>(options => options.UseSqlite(connectionString));
builder.Services.AddIdentityApiEndpoints<Client>().AddEntityFrameworkStores<ContextDB>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => { options.SaveToken = true; options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { ValidateIssuer = true, ValidateAudience = true, ValidateLifetime = true, ValidateIssuerSigningKey = true, ValidIssuer = builder.Configuration["Jwt:Issuer"], ValidAudience = builder.Configuration["Jwt:Audience"], IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])) }; });
var app = builder.Build();

app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "Error no controlado en {Path}", context.Request.Path);
        var statusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
        var problem = new ProblemDetails { Status = statusCode, Title = "Ocurrió un error", Detail = exception?.Message, Instance = context.Request.Path };
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problem);
    });
});
app.UseCors();
app.UseAuthentication();
app.MapControllers();

app.Run();
