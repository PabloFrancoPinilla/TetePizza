using Microsoft.AspNetCore.Mvc;
using TetePizza.Models;
using TetePizza.Service;

namespace TetePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => _pizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            _pizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = _pizzaService.Get(id);
            if (existingPizza == null)
                return NotFound();

            _pizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            _pizzaService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}/AddIngredient")]
        public IActionResult AddIngredient(int id, int ingredienteId)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            _pizzaService.AddIngredient(id, ingredienteId);

            return NoContent();
        }

        [HttpPut("{id}/DeleteIngredient")]
        public IActionResult DeleteIngredient(int id, int ingredienteId)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            _pizzaService.DeleteIngredient(id, ingredienteId);

            return NoContent();
        }
    }
}
