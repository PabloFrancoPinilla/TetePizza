namespace TetePizza.Data;
using TetePizza.Models;

public interface IIngredienteRepository
{
    List<Ingrediente> GetAll();
    Ingrediente Get(int id);
    void Add(Ingrediente ingrediente);
    void Delete(int id);
    void Update(Ingrediente ingrediente);

}