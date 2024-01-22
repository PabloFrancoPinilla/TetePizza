using Microsoft.AspNetCore.Mvc;
using TetePizza.Models;
using TetePizza.Service;

namespace TetePizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteService _IngredienteService;

        public IngredienteController(IngredienteService IngredienteService)
        {
            _IngredienteService = IngredienteService;
        }

        [HttpGet]
        public ActionResult<List<Ingrediente>> GetAll() => _IngredienteService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Ingrediente> Get(int id)
        {
            var Ingrediente = _IngredienteService.Get(id);

            if (Ingrediente == null)
                return NotFound();

            return Ingrediente;
        }

        [HttpPost]
        public IActionResult Create(Ingrediente Ingrediente)
        {
            _IngredienteService.Add(Ingrediente);
            return CreatedAtAction(nameof(Get), new { id = Ingrediente.Id }, Ingrediente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ingrediente Ingrediente)
        {
            if (id != Ingrediente.Id)
                return BadRequest();

            var existingIngrediente = _IngredienteService.Get(id);
            if (existingIngrediente == null)
                return NotFound();

            _IngredienteService.Update(Ingrediente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Ingrediente = _IngredienteService.Get(id);

            if (Ingrediente == null)
                return NotFound();

            _IngredienteService.Delete(id);

            return NoContent();
        }
    }
}