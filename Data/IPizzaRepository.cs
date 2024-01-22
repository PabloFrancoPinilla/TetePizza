 using TetePizza.Models;
 namespace TetePizza.Data;
 public interface IPizzaRepository
    {
        List<Pizza> GetAll();
        Pizza? Get(int id);
        void Add(Pizza pizza);
        void Delete(int id);
        void Update(Pizza pizza);
        void AddIngredient(int pizzaId, int ingredientId);
        void DeleteIngredient(int pizzaId, int ingredientId);
    }
 