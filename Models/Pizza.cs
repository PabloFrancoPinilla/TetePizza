namespace TetePizza.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public List<Ingrediente> PizzaIngredients{get;set;}= new List<Ingrediente>();
    }

