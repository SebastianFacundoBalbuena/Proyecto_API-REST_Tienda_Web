using System;
using System.Collections.Generic;

namespace API_REST.DataBase;

public partial class Registro
{
    public int Id { get; set; }

    public string? Producto { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? FechaDeVenta { get; set; }

    public decimal? Precio { get; set; }

    public string? Codigo { get; set; }
}
