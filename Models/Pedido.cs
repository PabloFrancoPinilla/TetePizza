namespace TetePizza.Models;

    public class Pedido
    {
        public int Id { get; set; }
        public List<Pizza> PizzaList { get; set; } = new List<Pizza>();
        public double Precio{get; set;}    
        public User user{get;set;}
    }

