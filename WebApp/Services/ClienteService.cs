using WebApp.Models;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services;

public class ClienteService : IClienteService
{
    private readonly MentumDbContext _context;
    public ClienteService(MentumDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }
    public async Task<List<Cliente>> GetClientesConContactos()
    {
        return await _context.Clientes.Include(c => c.Contactos).ToListAsync();
    }
    public async Task<Cliente?> GetClienteById(int id)
    {
        return await _context.Clientes
            .Include(c => c.Contactos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Cliente> CreateCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
    public async Task<Cliente> UpdateCliente(int id, Cliente cliente)
    {
        var existente = await _context.Clientes.FindAsync(id);
        if (existente == null)
            return null;

        existente.NombreCompleto = cliente.NombreCompleto;
        existente.Direccion = cliente.Direccion;
        existente.Telefono = cliente.Telefono;

        await _context.SaveChangesAsync();
        return existente;
    }
    public async Task<bool> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
}