using TetePizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace TetePizza.Data;

public class UserRepository : IUserRepository
{
    private readonly IPedidoRepository _pedidoRepository;
    private List<User> Users { get; set; } = new List<User>();

    private int nextId = 0;
    private int nextPedidoId = 0;
    public UserRepository(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;

        Users = new List<User>
        {

        };
    }

    public List<User> GetAll() => Users;

    public User? Get(int id) => Users.FirstOrDefault(p => p.Id == id);
    public void Add(User user)
    {
        user.Id = nextId++;
        Users.Add(user);

    }
    public Pedido CreatePedido(int userId, Pedido pedido)
    {
        var user = Get(userId);
        if (user != null)
        {
            var newPedido = new Pedido
            {
                Id =  Interlocked.Increment(ref nextPedidoId),
                User = user,
                PizzaList = pedido.PizzaList,
                Precio = pedido.Precio
            };
            _pedidoRepository.Add(newPedido);
            return newPedido;  
        }
        return null;
    }


    public void Delete(int id)
    {
        var User = Get(id);
        if (User is null)
            return;

        Users.Remove(User);
    }

    public void Update(User User)
    {
        var index = Users.FindIndex(p => p.Id == User.Id);
        if (index == -1)
            return;

        Users[index] = User;
    }

}

