using Microsoft.AspNetCore.Mvc;
using TetePizza.Models;
using TetePizza.Service;

namespace TetePizza.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public ActionResult<List<Pedido>> GetAll() => _pedidoService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null)
                return NotFound();

            return pedido;
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, Pedido pedido)
        {
            if (id != pedido.Id)
                return BadRequest();

            var existingPedido = _pedidoService.Get(id);
            if (existingPedido == null)
                return NotFound();

            _pedidoService.Update(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null)
                return NotFound();

            _pedidoService.Delete(id);

            return NoContent();
        }
    }

