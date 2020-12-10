using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework.Security;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio
{
    /// <summary>
    /// Criteria para recuperar listado de sesiones de acceso al sistema
    /// </summary>
    [Serializable]
    public class SesionCriteria
    {
 
        [StringLength(50)]
        public string Cuenta { get; set; }


        public EstadoSesion? Estado { get; set; }

        /// <summary>
        /// Fecha de inicio de Sesion 
        /// </summary>
        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Mensajes), ErrorMessageResourceName = "DataTypeAttribute_DateValidationError")]
        public DateTime? Fecha { get; set; }

        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int NumeroPagina { get; set; }

    }
}
