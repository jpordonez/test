using System;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;
using System.Collections.Generic;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Dominio.Entidades
{

    /// <summary>
    /// Representa una Accion que se puede realizar en una funcionalidad (Editar, Crear, Eliminar, Visualizar, Imprimir, etc.)
    /// </summary>
    [Serializable]
    public class Accion : IEntityNamed, IVersionable
    {
        public Accion()
        {
            Permisos = new List<Permiso>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Codigo de la accion. Esta accion se utiliza para mapear las acciones de los controladores en MVC
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(30)]
        public string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public int FuncionalidadId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public virtual Funcionalidad Funcionalidad { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }

        public int VersionRegistro
        {
            get;
            set;
        }

    }
}
