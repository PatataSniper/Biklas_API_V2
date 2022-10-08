global using Biklas_API_V2.Data;
global using Microsoft.EntityFrameworkCore;
global using Biklas_API_V2.Services;
global using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEncriptador, Encriptador>();
builder.Services.AddScoped<IComunicadorCorreo, ComunicadorCorreo>();
builder.Services.AddScoped<ICalculadorRuta, CalculadorRuta>();
builder.Services.AddScoped<IFileShare, AzureFileShare>();

// Agregamos el servicio de configuraci�n como un elemento 'singleton', para tener acceso
// a el desde cualquier clase. Gracias a la respuesta de Henk Mollema en StackOverflow:
// https://stackoverflow.com/questions/39231951/how-do-i-access-configuration-in-any-class-in-asp-net-core
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Agregamos pol�tica CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
