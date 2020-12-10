using System;
using System.ComponentModel.DataAnnotations;
using Framework;
using Framework.Security;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Seguridad
{
    /// <summary>
    /// Sesion de un usuario 
    /// </summary>
    [Serializable]
    public class Sesion : IEntity, IVersionable, IEntitySesion
    {


        public int Id { get; set; }

        /// <summary>
        /// cuenta del usuario
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(50)]
        public string Cuenta { get; set; }

        /// <summary>
        /// Inicio de sesion del usuario 
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public DateTime Inicio { get; set; }


        /// <summary>
        /// Fecha de fin de sesion del usuario
        /// </summary>
        public DateTime? Fin { get; set; }

        /// <summary>
        ///Estado. sesion iniciada, sesion finalizada
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public EstadoSesion EstadoId { get; set; }


        /// <summary>
        /// Direccion IP del usuario que inicio la sesion
        /// </summary>
        public string IpAddress { get; set; }


        /// <summary>
        /// Identificador del Rol con el cual inicio la sesion
        /// </summary>
        public int RolId { get; set; }


        public int VersionRegistro
        {
            get;
            set;
        }
    }
}
