using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework;
using Framework.Security;
using Nucleo.Dominio.Recursos;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Dominio.Seguridad
{

    /// <summary>
    /// Representa un Usuario
    /// </summary>
    [Serializable]
    public class Usuario : IEntity, IVersionable, IUsuario
    {
        public Usuario()
        {
            Roles = new List<Rol>();
        }
 
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        public string Cuenta { get; set; }

        public int? PersonaId { get; set; }

        [NotMapped]
        public string Identificacion { get; set; }

        [NotMapped]
        public string Nombres { get; set; }

        [NotMapped]
        public string Apellidos { get; set; }

        [NotMapped]
        public string Correo { get; set; }

        [NotMapped]
        public string EstadoNombre { get { return Estado == Estado.Activo ? "Activo" : "Inactivo"; } set{} }       

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public string Clave { get; set; }

        public Estado Estado  { get; set; }

        public virtual Persona Persona { get; set; }

        /// <summary>
        /// Listado de Roles que posee el Usuario
        /// </summary>
        public virtual ICollection<Rol> Roles { get; set; }


        public override string ToString()
        {
            return Cuenta;
        }
        
        public int VersionRegistro
        {
            get;
            set;
        }

    }
}
