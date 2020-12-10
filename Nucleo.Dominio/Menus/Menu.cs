using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Menus
{

    /// <summary>
    /// Representa un Menu
    /// </summary>
    [Serializable]
    public class Menu : IEntityNamed, IVersionable
    {
        public Menu()
        {
            this.Items = new List<MenuItem>();
        }


        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        public virtual string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public virtual string Nombre { get; set; }


        [StringLength(255)]
        public virtual string Descripcion { get; set; }

        //[Required(ErrorMessageResourceType = typeof (Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        //public virtual int EstadoId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public int SistemaId { get; set; }

        public virtual Sistema Sistema { get; set; }


        public virtual ICollection<MenuItem> Items { get; set; }

        
        public virtual int VersionRegistro
        {
            get;
            set;
        }
    }
}
