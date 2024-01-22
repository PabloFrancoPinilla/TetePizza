namespace TetePizza.Data;
using TetePizza.Models;

public class IngredienteRepository : IIngredienteRepository{
    public List<Ingrediente> Ingredientes {get; set;}= new List<Ingrediente>();
    
    public IngredienteRepository(){
        Ingredientes = new List<Ingrediente>{
             new Ingrediente {Id=0, Name = "Tomato", Origin= "Vegetable", Stock=100, Description ="So good" , IsVegan=true },
              new Ingrediente {Id=1, Name = "Cheese", Origin= "Animal", Stock=100, Description ="So good" , IsVegan=false },
            new Ingrediente {Id=2, Name = "Pepperoni", Origin= "Animal", Stock=100, Description ="So good" , IsVegan=false },
            new Ingrediente {Id=3, Name = "Onion", Origin= "Vegetable", Stock=100, Description ="Not as good" , IsVegan=true }

        };
    }
    private int nextId = 4;
     public List<Ingrediente> GetAll() => Ingredientes;

        public Ingrediente? Get(int id) => Ingredientes.FirstOrDefault(p => p.Id == id);

        public void Add(Ingrediente Ingrediente)
        {
            Ingrediente.Id = nextId++;
            Ingredientes.Add(Ingrediente);
        }

        public void Delete(int id)
        {
            var Ingrediente = Get(id);
            if (Ingrediente is null)
                return;

            Ingredientes.Remove(Ingrediente);
        }

        public void Update(Ingrediente Ingrediente)
        {
            var index = Ingredientes.FindIndex(p => p.Id == Ingrediente.Id);
            if (index == -1)
                return;

            Ingredientes[index] = Ingrediente;
        }
}
