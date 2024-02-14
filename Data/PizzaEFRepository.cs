using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TetePizza.Models;

namespace TetePizza.Data
{
    public class PizzaEFRepository : IPizzaRepository
    {
        private readonly PizzaContext _context;

        public PizzaEFRepository(PizzaContext context)
        {
            _context = context;
        }

        public List<Pizza> GetAll()
        {
            return  _context.Pizzas.ToList();
        }

        public  Pizza Get(int id)
        {
            return  _context.Pizzas.Find(id);
        }

        public  void Add(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
             _context.SaveChanges();
        }

        public void  Update(Pizza pizza)
        {
            _context.Entry(pizza).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void  Delete(int id)
        {
            var pizza =  _context.Pizzas.Find(id);
            _context.Pizzas.Remove(pizza);
             _context.SaveChanges();
        }
        public void AddIngredient(int pizzaId, int ingredientId){

        }
        public void DeleteIngredient(int pizzaId, int ingredientId){}
    }
}
