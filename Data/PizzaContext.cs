using Microsoft.EntityFrameworkCore;
using TetePizza.Models;
using Microsoft.Extensions.Configuration;

namespace TetePizza.Data
{
    public class PizzaContext : DbContext
    {

        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {

        }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Name = "Pepeorino", IsGlutenFree = true},
                new Pizza { Name = "Bacon", IsGlutenFree = false}
            );
            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente {  Name = "Cebolla", Origin="Vegetable", Stock = 100, Description = "Deposito inicial", IsVegan = true},
                new Ingrediente {  Name = "Pepeorino", Origin="Animal", Stock = 100, Description = "Deposito", IsVegan= false},
                new Ingrediente {  Name = "Tomato", Origin="Vegetal", Stock = 100, Description = "Retiro", IsVegan= true},
                new Ingrediente {  Name = "Cheese", Origin="Animal", Stock = 100, Description = "Deposito", IsVegan=false}
            );
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
       
    }
}
