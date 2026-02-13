namespace WebApp.DTOs.Responses;

public class ContactoResponse
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string NombreCompleto { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
}
