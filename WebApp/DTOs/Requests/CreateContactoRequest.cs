namespace WebApp.DTOs.Requests;

public class CreateContactoRequest
{
    public int ClienteId { get; set; }
    public string NombreCompleto { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

}