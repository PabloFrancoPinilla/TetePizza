using TetePizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace TetePizza.Data;

public class PizzaRepository : IPizzaRepository
{
    private List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    /* private int nextId = 3; */
    private readonly IIngredienteRepository _ingredienteRepository;
    public PizzaRepository(IIngredienteRepository ingredienteRepository)
    {
        var tomato = ingredienteRepository.Get(0);
        var cheese = ingredienteRepository.Get(1);
        var onion = ingredienteRepository.Get(3);
        _ingredienteRepository = ingredienteRepository;

        Pizzas = new List<Pizza>
            {
          /*       new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false, PizzaIngredients = new List<Ingrediente> { tomato, cheese } },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true , PizzaIngredients = new List<Ingrediente> { tomato, onion }} */
            };
    }

    public List<Pizza> GetAll() => Pizzas;

    public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        /* pizza.Id = nextId++; */
        Pizzas.Add(pizza);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
    public void AddIngredient(int pizzaId, int ingredienteId)
    {
      /*   var pizza = Pizzas.FirstOrDefault(p => p.Id == pizzaId);
        var ingrediente = _ingredienteRepository.Get(ingredienteId);

        if (pizza != null && ingrediente != null)
        {
            pizza.PizzaIngredients.Add(ingrediente);
        } */
    }
     public void DeleteIngredient(int pizzaId, int ingredienteId)
    {
      /*   var pizza = Pizzas.FirstOrDefault(p => p.Id == pizzaId);
        var ingrediente = _ingredienteRepository.Get(ingredienteId);

        if (pizza != null && ingrediente != null)
        {
            pizza.PizzaIngredients.Remove(ingrediente);
        } */
    }
}

