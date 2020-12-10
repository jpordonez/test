using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nucleo.Presentacion.Models
{
    public class RolDetalleViewModel : AuditableEntityViewModel
    {

        public int Id { get; set; }

         [DisplayName("Código")]
        public string Codigo { get; set; }


        public string Nombre { get; set; }

        /// <summary>
        /// Si el rol es administrador
        /// </summary>
        [DisplayName("Es Administrador")]
        public bool EsAdministrador { get; set; }

        /// <summary>
        /// Si el rol es externo (AD) o es interno Carpeta Linea
        /// </summary>
        [DisplayName("Rol Externo")]
        public bool EsExterno { get; set; }


        [StringLength(255)]
        [DisplayName("URL Inicio")]
        public string Url { get; set; }
    }
}