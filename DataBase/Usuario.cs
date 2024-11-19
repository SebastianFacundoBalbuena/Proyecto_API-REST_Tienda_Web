using System;
using System.Collections.Generic;

namespace API_REST.DataBase;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Contraseña { get; set; }

    public int? TipoDeUsuario { get; set; }

    public DateOnly? FechaDeNacimiento { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? ImagenPerfil { get; set; }
}
