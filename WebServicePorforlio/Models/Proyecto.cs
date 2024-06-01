using System;
using System.Collections.Generic;

namespace WebServicePorforlio.Models;

public partial class Proyecto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }
}
