using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Menus;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Entidades
{
    /// <summary>
    /// Representa un Sistema
    /// </summary>
    [Serializable]
    public class Sistema : IEntityNamed, IVersionable
    {
        public Sistema()
        {
            Funcionalidades = new List<Funcionalidad>();
            Parametros = new List<ParametroSistema>();
            Catalogos = new List<Catalogo>();
            Menus = new List<Menu>();
        }


        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        public  string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public  string Nombre { get; set; }


        [StringLength(255)]
        public  string Descripcion { get; set; }

        /// <summary>
        /// Listado de Funcionalidades del sistmea
        /// </summary>
        public virtual ICollection<Funcionalidad> Funcionalidades { get; set; }

        /// <summary>
        /// Listado de Parametros del Sistema
        /// </summary>
        public virtual ICollection<ParametroSistema> Parametros { get; set; }

        /// <summary>
        /// Listado de Catalogos del Sistema
        /// </summary>
        public virtual ICollection<Catalogo> Catalogos { get; set; }

        /// <summary>
        /// Listado de Menus del Sistema
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }

         
        public  int VersionRegistro
        {
            get;
            set;
        }
    }
}
