using System;
using System.Collections.Generic;

namespace WebServicePorforlio.Models;

public partial class DescripcionPersonal
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
