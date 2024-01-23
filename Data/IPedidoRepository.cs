namespace TetePizza.Data;
using TetePizza.Models;

 public interface IPedidoRepository
    {
        List<Pedido> GetAll();
        Pedido Get(int id);
        void Add(Pedido pedido);
        void AddPizza(int id,Pizza pizza);
        void RemovePizza(int id,Pizza pizza);
        void Delete(int id);
        void Update(Pedido pedido);

    }