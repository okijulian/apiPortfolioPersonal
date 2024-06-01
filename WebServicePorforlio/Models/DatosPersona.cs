using System;
using System.Collections.Generic;

namespace WebServicePorforlio.Models;

public partial class DatosPersona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Email { get; set; }

    public long? Telefono { get; set; }
}
