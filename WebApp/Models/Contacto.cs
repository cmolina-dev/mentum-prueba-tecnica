using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Contacto
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
