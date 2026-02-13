using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Models;
using WebApp.DTOs.Requests;
using WebApp.DTOs.Responses;

namespace WebApp.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ContactosController : ControllerBase
{
    private readonly IContactoService _service;

    public ContactosController(IContactoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ContactoResponse>>> GetContactos()
    {
        var contactos = await _service.GetContactos();
        return Ok(contactos);
    }
    [HttpGet("cliente/{id}")]
    public async Task<ActionResult<List<ContactoResponse>>> GetContactosDeCliente(int id)
    {
        var contactos = await _service.GetContactosDeCliente(id);
        return Ok(contactos);
    }
    [HttpPost]
    public async Task<ActionResult<CreateContactoResponse>> CrearContacto([FromBody] CreateContactoRequest request)
    {
        var resultado = await _service.CreateContacto(request);
        return Ok(resultado);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateContactoResponse>> ActualizarContacto(int id, [FromBody] UpdateContactoRequest request)
    {
        var resultado = await _service.UpdateContacto(id, request);
        return Ok(resultado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarContacto(int id)
    {
        var result = await _service.DeleteContacto(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}