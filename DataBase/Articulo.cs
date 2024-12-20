﻿using System;
using System.Collections.Generic;

namespace API_REST.DataBase;

public partial class Articulo
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdMarca { get; set; }

    public int? IdCategoria { get; set; }

    public string? ImagenUrl { get; set; }

    public decimal? Precio { get; set; }
}
