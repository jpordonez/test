using System;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Menus
{
    /// <summary>
    /// Item de Menu
    /// </summary>
    [Serializable]
    public class MenuItem : IEntityNamed, IVersionable
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        public string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public string Nombre { get; set; }


        [StringLength(255)]
        public string Descripcion { get; set; }

        [StringLength(255)]
        public string Url { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public EstadoItemMenu EstadoId { get; set; }

        /// <summary>
        /// Tipo del Item de Menu (Contenedor / Item Menu)
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public TipoItemMenu TipoId { get; set; }

        /// <summary>
        /// Orden del item menu
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public int Orden { get; set; }

        /// <summary>
        /// Icono del item menu
        /// </summary>
        public string Icono { get; set; }

        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }

        [StringLength(15)]
        public string PadreCodigo { get; set; }        

        public int? FuncionalidadId { get; set; }


        ///// <summary>
        ///// Funcionalidad asociada al menu
        ///// </summary>
        //public virtual Funcionalidad Funcionalidad { get; set; }


        public int VersionRegistro
        {
            get;
            set;
        }
    }


    public enum EstadoItemMenu
    {
        Desactivo = 0,
        Activo = 1
    }


    public enum TipoItemMenu
    {
        Contenedor = 1,
        ItemMenu = 2
    }
}
