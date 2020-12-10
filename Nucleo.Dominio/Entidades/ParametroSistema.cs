using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Entidades
{
    
    /// <summary>
    /// Representa un Parametros del sistema
    /// </summary>
    [Serializable]
    public class ParametroSistema : AuditableEntity<ParametroSistema>, IEntityNamed, IVersionable
    {
        public ParametroSistema()
        {
            Opciones = new List<ParametroOpcion>();
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(15)]
        [DisplayName("Código")]
        public  string Codigo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [StringLength(255)]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Categoria del parametro. 
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [DisplayName("Categoría")]
        public CategoriaParametro Categoria { get; set; }

        /// <summary>
        /// Tipo del Parametro. (Valor Simple, Lista de Valores, Json)
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public TipoParametro Tipo { get; set; }


        /// <summary>
        /// Valor del parametro
        /// </summary>
        //[StringLength(255)]
         [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public string Valor { get; set; }
        
        /// <summary>
        /// Si el parametro es editable por el usuario (UI)
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [DisplayName("Es editable?")]
        public bool EsEditable
        {
            get;
            set;
        }

        /// <summary>
        /// Si el parametro posee opciones
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [DisplayName("Posee Opciones")]
        public bool TieneOpciones
        {
            get;
            set;
        }


        /// <summary>
        /// Listado de opciones, para tipos de parametros Listas
        /// </summary>
        public virtual ICollection<ParametroOpcion> Opciones { get; set; }


        /// <summary>
        /// Sistema. Identificador
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public  int SistemaId { get; set; }

        public virtual Sistema Sistema { get; set; }


        
        public virtual int VersionRegistro
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Tipos de Parametros
    /// </summary>
    public enum TipoParametro
    {
        Numero = 1,
        Cadena = 2,
        Booleano = 3,
        Listado = 4,
        Fecha = 5
    }

    

    /// <summary>
    /// Categoria de Parametros
    /// </summary>
    public enum CategoriaParametro
    {
        General = 1
    }


}
