namespace TetePizza.Service;

using System.Xml.Serialization;
using TetePizza.Models;

public interface IPizzaService{
    List<Pizza>GetAll();
    Pizza? Get(int id);
    void Add(Pizza pizza);
    void Update(Pizza pizza);
    void Delete(int id);
    void AddIngredient(int pizzaId, int ingredientId);
    void DeleteIngredient(int pizzaId, int ingredientId);

}