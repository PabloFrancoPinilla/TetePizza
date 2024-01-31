namespace TetePizza.Service;

using System.Xml.Serialization;
using TetePizza.Models;

public interface IPedidoService
{
    List<Pedido> GetAll();
    Pedido? Get(int id);
    void AddPizza(int id, Pizza pizza);
    void RemovePizza(int id, Pizza pizza);
    void Delete(int id);
    void Update(Pedido pedido);
    void AddPedido(Pedido pedido);

}