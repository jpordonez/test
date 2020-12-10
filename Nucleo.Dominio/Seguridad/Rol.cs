using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Seguridad
{

    /// <summary>
    /// Representa un Rol de Seguridad
    /// </summary>
    [Serializable]
    public class Rol : AuditableEntity<Rol>, IEntityNamed, IVersionable, IEquatable<Rol>
    {

        public Rol()
        {
            Usuarios = new List<Usuario>();
            Permisos = new List<Permiso>();
        }

        public int Id { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(30)]
        [DisplayName("Código")]
        public  string Codigo { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public  string Nombre { get; set; }

        /// <summary>
        /// Si el rol es administrador
        /// </summary>
         [DisplayName("Es Administrador")]
        public bool EsAdministrador { get; set; }

        /// <summary>
        /// Si el rol es externo (AD) o es interno Carpeta Linea
        /// </summary>
        [DisplayName("Rol Externo")]
        public bool EsExterno { get; set; }

        [StringLength(255)]
        [DisplayName("URL Inicio")]
        public string Url { get; set; }

        public string Parametros { get; set; }


        /// <summary>
        /// Listado de usuarios
        /// </summary>
        public virtual ICollection<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Listado de acciones/funcionalidades que tiene permisos el rol
        /// </summary>
        public virtual ICollection<Permiso> Permisos { get; set; }

         
        public  int VersionRegistro
        {
            get;
            set;
        }

        public bool Equals(Rol other)
        {
            if (other == null) return false;
            return (this.Codigo.Equals(other.Codigo));
        }
    }

}
