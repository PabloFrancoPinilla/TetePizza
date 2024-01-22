namespace TetePizza.Data;
using TetePizza.Models;

 public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        void Delete(int id);
        void Update(User pedido);

    }