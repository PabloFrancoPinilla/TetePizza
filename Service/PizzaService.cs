
using TetePizza.Data;
using TetePizza.Models;
namespace TetePizza.Service;

    public class PizzaService
{
   private readonly IPizzaRepository _pizzaRepository;

    public PizzaService(IPizzaRepository pizzaRepository)
    {
        _pizzaRepository = pizzaRepository;
    }
    public List<Pizza> GetAll() => _pizzaRepository.GetAll();

    public Pizza? Get(int id) => _pizzaRepository.Get(id);

    public void Add(Pizza pizza) => _pizzaRepository.Add(pizza);

    public void Update(Pizza pizza) => _pizzaRepository.Update(pizza);

    public void Delete(int id) => _pizzaRepository.Delete(id);
    public void AddIngredient(int pizzaId, int ingredientId) => _pizzaRepository.AddIngredient(pizzaId,ingredientId);
    public void DeleteIngredient(int pizzaId, int ingredientId) => _pizzaRepository.DeleteIngredient(pizzaId,ingredientId); 
}
