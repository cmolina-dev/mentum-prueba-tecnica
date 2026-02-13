using WebApp.Models;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApp.DTOs.Requests;
using WebApp.DTOs.Responses;


namespace WebApp.Services;

public class ContactoService : IContactoService
{
    private readonly MentumDbContext _context;
    public ContactoService(MentumDbContext context)
    {
        _context = context;
    }
    public async Task<List<ContactoResponse>> GetContactos()
    {
        var contactos = await _context.Contactos.ToListAsync();
        return contactos.Select(c => new ContactoResponse
        {
            Id = c.Id,
            ClienteId = c.ClienteId,
            NombreCompleto = c.NombreCompleto,
            Direccion = c.Direccion,
            Telefono = c.Telefono
        }).ToList();
    }
    public async Task<List<ContactoResponse>> GetContactosDeCliente(int id)
    {
        var contactos = await _context.Contactos.Where(c => c.ClienteId == id).ToListAsync();
        return contactos.Select(c => new ContactoResponse
        {
            Id = c.Id,
            ClienteId = c.ClienteId,
            NombreCompleto = c.NombreCompleto,
            Direccion = c.Direccion,
            Telefono = c.Telefono
        }).ToList();
    }
    public async Task<CreateContactoResponse> CreateContacto(CreateContactoRequest request)
    {
        try
        {
            //validar que el cliente existe
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == request.ClienteId);
            if (!clienteExiste)
            {
                return new CreateContactoResponse
                {
                    Exitoso = false,
                    Mensaje = "El cliente no existe"
                };
            }
            // Crear el contacto
            var nuevoContacto = new Contacto
            {
                NombreCompleto = request.NombreCompleto,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                ClienteId = request.ClienteId
            };
            _context.Contactos.Add(nuevoContacto);
            await _context.SaveChangesAsync();

            return new CreateContactoResponse
            {
                Exitoso = true,
                Mensaje = "Contacto creado exitosamente",
                ContactoId = nuevoContacto.Id
            };
        }
        catch (Exception ex)
        {
            return new CreateContactoResponse
            {
                Exitoso = false,
                Mensaje = $"Error al crear contacto: {ex.Message}"
            };
        }
    }
    public async Task<UpdateContactoResponse> UpdateContacto(int id, UpdateContactoRequest request)
    {
        try
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return new UpdateContactoResponse
                {
                    Exitoso = false,
                    Mensaje = "Contacto no encontrado",
                    Contacto = null
                };
            }

            contacto.NombreCompleto = request.NombreCompleto;
            contacto.Direccion = request.Direccion;
            contacto.Telefono = request.Telefono;

            _context.Contactos.Update(contacto);
            await _context.SaveChangesAsync();

            return new UpdateContactoResponse
            {
                Exitoso = true,
                Mensaje = "Contacto actualizado exitosamente",
                Contacto = new ContactoResponse
                {
                    Id = contacto.Id,
                    ClienteId = contacto.ClienteId,
                    NombreCompleto = contacto.NombreCompleto,
                    Direccion = contacto.Direccion,
                    Telefono = contacto.Telefono
                }
            };
        }
        catch (Exception ex)
        {
            return new UpdateContactoResponse
            {
                Exitoso = false,
                Mensaje = $"Error al actualizar contacto: {ex.Message}",
                Contacto = null
            };
        }
    }
    public async Task<bool> DeleteContacto(int id)
    {
        try
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return false;
            }

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

}