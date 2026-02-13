using WebApp.Models;
using WebApp.DTOs.Requests;
using WebApp.DTOs.Responses;

namespace WebApp.Services;


public interface IContactoService
{
    Task<List<ContactoResponse>> GetContactos();
    Task<List<ContactoResponse>> GetContactosDeCliente(int id);
    Task<CreateContactoResponse> CreateContacto(CreateContactoRequest contacto);
    Task<UpdateContactoResponse> UpdateContacto(int id, UpdateContactoRequest contacto);
    Task<bool> DeleteContacto(int id);
}