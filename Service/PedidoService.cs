using TetePizza.Data;
using TetePizza.Models;

namespace TetePizza.Service;
public class PedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public List<Pedido> GetAll() => _pedidoRepository.GetAll();

    public Pedido Get(int id) => _pedidoRepository.Get(id);

    public void AddPizza(int id, Pizza pizza) => _pedidoRepository.AddPizza(id, pizza);

    public void RemovePizza(int id, Pizza pizza) => _pedidoRepository.RemovePizza(id, pizza);

    public void Delete(int id) => _pedidoRepository.Delete(id);

    public void Update(Pedido pedido) => _pedidoRepository.Update(pedido);

    public void AddPedido(Pedido pedido) => _pedidoRepository.Add(pedido);
}
