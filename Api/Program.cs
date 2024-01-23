using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TetePizza.Data;
using TetePizza.Models;
using TetePizza.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza API", Version = "v1" });
});

builder.Services.AddSingleton<IIngredienteRepository, IngredienteRepository>();
builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddScoped<IngredienteService>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza API v1"));
}

app.UseAuthorization();
app.MapControllers();

app.Run();
