using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Entidades
{
    /// <summary>
    /// Representa un Catalogo del Sistema
    /// </summary>
    [Serializable]
    public class Catalogo : AuditableEntity<Catalogo>, IEntityNamed, IVersionable
    {
        public Catalogo()
        {
            this.Items = new List<ItemCatalogo>();
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        [DisplayName("Código")]
        public  string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public  string Nombre { get; set; }

        [StringLength(255)]
        [DisplayName("Descripción")]
        public  string Descripcion { get; set; }


       
        [DisplayName("Sistema")]
        public int SistemaId { get; set; }

        public virtual Sistema Sistema { get; set; }

        /// <summary>
        /// Listado de items del catalog
        /// </summary>
        public virtual ICollection<ItemCatalogo> Items { get; set; }
 
        public virtual int VersionRegistro
        {
            get;
            set;
        }
    }
}
