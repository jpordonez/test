using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework;
using Framework.Security;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Entidades
{
    /// <summary>
    /// Representa una Funcionalidad de un sistema
    /// </summary>
    [Serializable]
    public class Funcionalidad : IEntity, IVersionable
    {
        public Funcionalidad()
        {
            Acciones = new List<Accion>(); 
        }


        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        public  string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public  string Nombre { get; set; }

        [StringLength(255)]
        [DisplayName("Descripción")]
        public  string Descripcion { get; set; }


        /// <summary>
        /// Nombre del controlador que gestiona la funcionalidad. (MVC. Nombre del Controller)
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        
        public string Controlador { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public Estado EstadoId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [DisplayName("Sistema")]
        public  int SistemaId { get; set; }

        public virtual Sistema Sistema { get; set; }

        /// <summary>
        /// Listado de acciones que se permite realizar sobre esta funcionalidad
        /// </summary>
        public virtual ICollection<Accion> Acciones { get; set; }

        
        public  int VersionRegistro
        {
            get;
            set;
        }
    }


}
