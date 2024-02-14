using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TetePizza.Models;

namespace TetePizza.Data
{
    public class IngredienteEFRepository : IIngredienteRepository
    {
        private readonly PizzaContext _context;

        public IngredienteEFRepository(PizzaContext context)
        {
            _context = context;
        }

        public List<Ingrediente> GetAll()
        {
            return  _context.Ingredientes.ToList();
        }

        public  Ingrediente Get(int id)
        {
            return  _context.Ingredientes.Find(id);
        }

        public  void Add(Ingrediente Ingrediente)
        {
            _context.Ingredientes.Add(Ingrediente);
             _context.SaveChanges();
        }

        public void  Update(Ingrediente Ingrediente)
        {
            _context.Entry(Ingrediente).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void  Delete(int id)
        {
            var Ingrediente =  _context.Ingredientes.Find(id);
            _context.Ingredientes.Remove(Ingrediente);
             _context.SaveChanges();
        }
        public void AddIngredient(int IngredienteId, int ingredientId){

        }
        public void DeleteIngredient(int IngredienteId, int ingredientId){}
    }
}
