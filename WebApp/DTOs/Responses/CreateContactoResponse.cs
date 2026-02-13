namespace WebApp.DTOs.Responses;

public class CreateContactoResponse
{
    public bool Exitoso { get; set; }
    public string Mensaje { get; set; }
    public int? ContactoId { get; set; }
}