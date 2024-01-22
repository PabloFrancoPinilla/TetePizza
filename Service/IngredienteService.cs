
using TetePizza.Data;
using TetePizza.Models;
namespace TetePizza.Service;

    public class IngredienteService
{
   private readonly IIngredienteRepository _IngredienteRepository;

    public IngredienteService(IIngredienteRepository IngredienteRepository)
    {
        _IngredienteRepository = IngredienteRepository;
    }
    public List<Ingrediente> GetAll() => _IngredienteRepository.GetAll();

    public Ingrediente? Get(int id) => _IngredienteRepository.Get(id);

    public void Add(Ingrediente Ingrediente) => _IngredienteRepository.Add(Ingrediente);

    public void Update(Ingrediente Ingrediente) => _IngredienteRepository.Update(Ingrediente);

    public void Delete(int id) => _IngredienteRepository.Delete(id);
}
