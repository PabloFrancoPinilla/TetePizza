namespace TetePizza.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
public class Pizza
{
    [Key]
    public int Id { get; set; }
   
    [Required]
    public string Name { get; set; }
    
    [Required]
    public bool IsGlutenFree { get; set; }
    public List<PizzaIngrediente> PizzaIngredients { get; set; } 

    public Pizza (){}
}

