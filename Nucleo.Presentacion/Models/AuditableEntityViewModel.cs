using System;
using System.ComponentModel;
using Framework.MVC;

namespace Nucleo.Presentacion.Models
{
    public abstract class AuditableEntityViewModel : IViewModel
    {

        [DisplayName("Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        [DisplayName("Usuario Creación")]
        public string UsuarioCreacion { get; set; }


        [DisplayName("Fecha Actualización")]
        public DateTime? FechaActualizacion { get; set; }


        [DisplayName("Usuario Actualización")]
        public string UsuarioActualizacion { get; set; }
    }
}
