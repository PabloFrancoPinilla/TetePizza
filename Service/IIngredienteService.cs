namespace TetePizza.Service;

using System.Xml.Serialization;
using TetePizza.Models;

public interface IIngredienteService{
    List<Ingrediente>GetAll();
    Ingrediente? Get(int id);
    void Add(Ingrediente ingrediente);
    void Update(Ingrediente ingrediente);
    void Delete(int id);
    

}