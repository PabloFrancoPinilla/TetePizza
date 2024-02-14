using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TetePizza.Data;
using TetePizza.Models;
using TetePizza.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza API", Version = "v1" });
});
var connectionString = builder.Configuration.GetConnectionString("ServerDB");
/* builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider =>
    new PizzaSqlRepository(connectionString)); */

//builder.Services.AddScoped<IIngredienteRepository, IngredienteSqlRepository>(serviceProvider =>
//  new IngredienteSqlRepository(connectionString));
/* builder.Services.AddScoped<IngredienteService>(); */
builder.Services.AddScoped<PizzaService>();
/* builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<UserService>(); */
builder.Services.AddDbContext<PizzaContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPizzaRepository, PizzaEFRepository>();

/* builder.Services.AddScoped<IPizzaRepository, PizzaEFRepository>();

/* builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>(); */
/* builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); */



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza API v1"));


app.UseAuthorization();
app.MapControllers();

app.Run();
