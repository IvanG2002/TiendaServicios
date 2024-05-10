using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistence;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MediatR;
using TiendaServicios.Api.CarritoCompra.Application;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
builder.Services.AddDbContext<CarritoContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23)));
});
builder.Services.AddHttpClient("Libros", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Libros"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
