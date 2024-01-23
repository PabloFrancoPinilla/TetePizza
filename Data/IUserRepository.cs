namespace TetePizza.Data;
using TetePizza.Models;

public interface IUserRepository
{
    List<User> GetAll();
    User Get(int id);
    void Add(User user);
    void Delete(int id);
    void Update(User user);
    Pedido CreatePedido(int userId, Pedido pedido);
}