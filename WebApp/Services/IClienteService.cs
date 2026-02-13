using WebApp.Models;

namespace WebApp.Services;

public interface IClienteService
{
    Task<List<Cliente>> GetClientes();
    Task<List<Cliente>> GetClientesConContactos();
    Task<Cliente?> GetClienteById(int id);
    Task<Cliente> CreateCliente(Cliente cliente);
    Task<Cliente> UpdateCliente(int id, Cliente cliente);
    Task<bool> DeleteCliente(int id);

}