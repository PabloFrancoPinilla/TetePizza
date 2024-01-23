using TetePizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace TetePizza.Data;

public class PedidoRepository : IPedidoRepository
{
    private List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    private int nextId = 3;
    private readonly IIngredienteRepository _ingredienteRepository;
    public PedidoRepository(IIngredienteRepository ingredienteRepository)
    {

        _ingredienteRepository = ingredienteRepository;

        Pedidos = new List<Pedido>
        {

        };
    }

    public List<Pedido> GetAll() => Pedidos;

    public Pedido? Get(int id) => Pedidos.FirstOrDefault(p => p.Id == id);
     public void Add(Pedido pedido)
    {
        pedido.Id = nextId++;
        Pedidos.Add(pedido);
    }

    public void AddPizza(int id, Pizza pizza)
    {
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
        pedido.PizzaList.Add(pizza);
    }
    public void RemovePizza(int id, Pizza pizza)
    {
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
        pedido.PizzaList.Remove(pizza);
    }

    public void Delete(int id)
    {
        var Pedido = Get(id);
        if (Pedido is null)
            return;

        Pedidos.Remove(Pedido);
    }

    public void Update(Pedido Pedido)
    {
        var index = Pedidos.FindIndex(p => p.Id == Pedido.Id);
        if (index == -1)
            return;

        Pedidos[index] = Pedido;
    }

}

