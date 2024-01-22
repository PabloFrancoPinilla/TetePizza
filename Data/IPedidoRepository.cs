namespace TetePizza.Data;
using TetePizza.Models;

 public interface IPedidoRepository
    {
        List<Pedido> GetAll();
        Pedido Get(int id);
        void Delete(int id);
        void Update(Pedido pedido);

    }