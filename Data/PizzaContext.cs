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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<PizzaIngrediente>()
                   .HasKey(pi => new { pi.PizzaId, pi.IngredienteId });

            modelBuilder.Entity<PizzaIngrediente>()
                .HasOne(pi => pi.Pizza)
                .WithMany(p => p.PizzaIngredients)
                .HasForeignKey(pi => pi.PizzaId);

            modelBuilder.Entity<PizzaIngrediente>()
                .HasOne(pi => pi.Ingrediente)
                .WithMany(i => i.PizzaIngredients)
                .HasForeignKey(pi => pi.IngredienteId);
                
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Hawaiana", IsGlutenFree = true },
                new Pizza { Id = 2, Name = "Barbacoa", IsGlutenFree = true }
            );

            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { Id = 1, Name = "Cebolla", Origin = "Vegetable", Stock = 100, Description = "Descripción de la cebolla", IsVegan = true },
                new Ingrediente { Id = 2, Name = "Pepeorino", Origin = "Animal", Stock = 100, Description = "Descripción del pepeorino", IsVegan = false }
            );

            modelBuilder.Entity<PizzaIngrediente>().HasData(
                new PizzaIngrediente { PizzaId = 1, IngredienteId = 1 },
                new PizzaIngrediente { PizzaId = 1, IngredienteId = 2 }
              
            );
            /* 
                        modelBuilder.Entity<Ingrediente>()
                            .HasOne(ingrediente => ingrediente.Pizza)
                            .WithMany(pizza => pizza.PizzaIngredients)
                            .HasForeignKey(ingrediente => ingrediente.PizzaId); */

           
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

    }
}
