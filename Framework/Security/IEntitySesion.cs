using System;

namespace Framework.Security
{

    /// <summary>
    /// Interfaz para mantener informacion de una sesion de un usuario
    /// </summary>
    public interface IEntitySesion
    {
        /// <summary>
        /// Identificador de la sesion
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Cuenta del usuarios
        /// </summary>
        string Cuenta { get; set; }

        /// <summary>
        /// Estado de la sesion
        /// </summary>
        EstadoSesion EstadoId { get; set; }
        
        /// <summary>
        /// Inicio de la sesion 
        /// </summary>
        DateTime Inicio { get; set; }

        /// <summary>
        /// Fecha de finalizacion de la sesion
        /// </summary>
        DateTime? Fin { get; set; }
        
    }

    /// <summary>
    /// Estado de Sesion
    /// </summary>
    public enum EstadoSesion
    {
        Iniciada = 0,
        Finalizada = 1
    }  
}
