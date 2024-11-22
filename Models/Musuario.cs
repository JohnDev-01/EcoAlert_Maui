public class Usuario
{
    public int Id { get; set; } // Identificador único del usuario
    public string Nombre { get; set; } // Nombre completo del usuario
    public string Email { get; set; } // Correo electrónico del usuario
    public string Contraseña { get; set; } // Contraseña cifrada
    public DateTime FechaRegistro { get; set; } // Fecha en que se registró el usuario
    public bool Activo { get; set; } // Estado del usuario (activo/inactivo)

    public Usuario()
    {
        FechaRegistro = DateTime.Now; // Inicializar con la fecha actual
        Activo = true; // Por defecto, un usuario está activo
    }
}
