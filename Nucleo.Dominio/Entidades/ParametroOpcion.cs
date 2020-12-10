using System;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio.Entidades
{
    /// <summary>
    /// Opcion de parametro
    /// </summary>
    [Serializable]
    public class ParametroOpcion : IEntity, IVersionable
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(30)]
        public string Valor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        [StringLength(255)]
        public string Texto { get; set; }


        /// <summary>
        /// Identificador del Parametro
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "RequiredAttribute_ValidationError")]
        public int ParametroId { get; set; }

        public virtual ParametroSistema Parametro { get; set; }

        public virtual int VersionRegistro
        {
            get;
            set;
        }
    }
}
