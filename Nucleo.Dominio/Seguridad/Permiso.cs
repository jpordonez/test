using System;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Seguridad
{
    [Serializable]
    public  class Permiso: IEntity, IVersionable //AuditableEntity<Permiso>, IVersionable
    {

        public int Id { get; set; }


         [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }


         [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public int AccionId { get; set; }
 
        public virtual Accion Accion { get; set; }

        public bool NoVisualizarEnMenu { get; set; }

        public int VersionRegistro
        {
            get;
            set;
        }

    }
}
