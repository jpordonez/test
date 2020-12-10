using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Entidades
{
    /// <summary>
    /// Representa un item de un  Catalogo del Sistema
    /// </summary>
    [Serializable]
    public class ItemCatalogo : AuditableEntity<ItemCatalogo>, IEntityNamed, IVersionable
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        [DisplayName("Código")]
        public  string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        public string CodigoCatalogo { get; set; }

        public int? CatalogoId { get; set; }

        public virtual Catalogo Catalogo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [StringLength(255)]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        
        public bool Estado { get; set; }

        public int VersionRegistro
        {
            get;
            set;
        }
    }
}
