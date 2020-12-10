using System;
using System.ComponentModel.DataAnnotations;

namespace Framework
{
    /// <summary>
    /// Interfaz de una entidad
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Identificador de una entidad
        /// </summary>
        int Id { get; }
    }

    /// <summary>
    /// Intefaz de una entidad nombrada
    /// </summary>
    public interface IEntityNamed : IEntity
    {
         
        /// <summary>
        /// Codigo de la entidad
        /// </summary>
           string Codigo { get; set; }

        /// <summary>
        /// Nombre de la Entidad
        /// </summary>
       string Nombre { get; set; }
    }

    /// <summary>
    /// Entidad con rastros de auditoria
    /// </summary>
    public interface IAuditableEntity 
    {
        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Usuario de creacion registro. Identificador
        /// </summary>
        int UsuarioCreacionId { get; set; }

        /// <summary>
        /// Fecha de actualizacion
        /// </summary>
        DateTime? FechaActualizacion { get; set; }

        /// <summary>
        /// Usuario que actualizo el registro. Identificador
        /// </summary>
        int? UsuarioActualizacionId { get; set; }
    }


    [Serializable]
    public abstract class AuditableEntity<T> :  IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime FechaCreacion { get; set; }

        [ScaffoldColumn(false)]
        public int UsuarioCreacionId { get; set; }


        [ScaffoldColumn(false)]
        public DateTime? FechaActualizacion { get; set; }


        [ScaffoldColumn(false)]
        public int? UsuarioActualizacionId { get; set; }
    }
}
