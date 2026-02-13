namespace WebApp.DTOs.Responses;

public class UpdateContactoResponse
{
    public bool Exitoso { get; set; }
    public string Mensaje { get; set; }
    public ContactoResponse Contacto { get; set; }
}
