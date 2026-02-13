using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
