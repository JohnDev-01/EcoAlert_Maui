public class Contacto
{
    public int Id { get; set; } // Identificador único del contacto
    public int UsuarioId { get; set; } // Identificador del usuario al que pertenece este contacto
    public string Nombre { get; set; } // Nombre del contacto
    public string Telefono { get; set; } // Número de teléfono del contacto
    public string Email { get; set; } // Correo electrónico del contacto
    public string Relacion { get; set; } // Relación con el usuario (amigo, familiar, compañero, etc.)
    public DateTime FechaCreacion { get; set; } // Fecha en que se creó el contacto

    public Contacto()
    {
        FechaCreacion = DateTime.Now; // Inicializar con la fecha actual
    }
}
