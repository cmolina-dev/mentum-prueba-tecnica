using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Models;

namespace WebApp.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _service.GetClientes();
        return Ok(clientes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _service.GetClienteById(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
    {
        var resultado = await _service.CreateCliente(cliente);
        return CreatedAtAction(nameof(GetClienteById), new { id = resultado.Id }, resultado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
    {
        var resultado = await _service.UpdateCliente(id, cliente);
        if (resultado == null)
            return NotFound();
        return Ok(resultado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var resultado = await _service.DeleteCliente(id);
        if (!resultado)
            return NotFound();
        return NoContent();
    }

}