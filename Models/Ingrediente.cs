using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TetePizza.Models
{
    public class Ingrediente
    {
        [Key]
         
        public int Id { get; set; }
        [Column (TypeName ="NVARCHAR(100)")]
        [Required]
        public string Name { get; set; }
       
        public string Origin { get; set; }
        
        public int? Stock { get; set; }
        
        public string Description { get; set; }
       
        public bool IsVegan { get; set; }
        public List<PizzaIngrediente> PizzaIngredients { get; set; } 
        public Ingrediente (){}
    }
}