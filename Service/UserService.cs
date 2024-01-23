using TetePizza.Data;
using System.Collections.Generic;
using TetePizza.Models;

namespace TetePizza.Service;
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPedidoRepository _pedidoRepository;

    public UserService(IUserRepository userRepository, IPedidoRepository pedidoRepository)
    {
        _userRepository = userRepository;
        _pedidoRepository = pedidoRepository;
    }

    public List<User> GetAll() => _userRepository.GetAll();

    public User Get(int id) => _userRepository.Get(id);

    public void Add(User user) => _userRepository.Add(user);

    public Pedido CreatePedido(int userId, Pedido pedido) => _userRepository.CreatePedido(userId, pedido);

    public void Delete(int id) => _userRepository.Delete(id);

    public void Update(User user) => _userRepository.Update(user);
}
