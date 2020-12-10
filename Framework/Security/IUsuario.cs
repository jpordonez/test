namespace Framework.Security
{

    /// <summary>
    /// Interfaz de informacion de un usuario
    /// </summary>
    public interface IUsuario
    {
        string Identificacion { get; set; }
        string Apellidos { get; set; }
        string Correo { get; set; }
        string Cuenta { get; set; }
        int Id { get; set; }
        string Nombres { get; set; }
        string EstadoNombre { get; set; }
    }
}
