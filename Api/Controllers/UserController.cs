namespace TetePizza.Controllers;
using Microsoft.AspNetCore.Mvc;
using TetePizza.Models;
using TetePizza.Data;
using TetePizza.Service;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly PedidoService _pedidoService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() => _userService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id) => _userService.Get(id);

    [HttpPost]
    public IActionResult Add(User user)
    {
        _userService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPost("{userId}/CreatePedido")]
    public IActionResult CreatePedido(int userId, Pedido pedido)
    {
        var createdPedido = _userService.CreatePedido(userId, pedido);

        if (createdPedido != null)
        {
           return CreatedAtAction("Get", "Pedido", new { id = createdPedido.Id }, createdPedido);

        }
        else
        {
            return BadRequest("Error al crear el pedido.");
        }
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        _userService.Update(user);
        return NoContent();
    }
}
