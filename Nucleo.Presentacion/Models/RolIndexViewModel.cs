using System.Collections.Generic;
using Framework.MVC;
using Nucleo.Dominio.Seguridad;
using Nucleo.Presentacion.Helpers;

namespace Nucleo.Presentacion.Models
{
    public class RolIndexViewModel : IViewModel
    {

        public IEnumerable<Rol> Roles { get; set; }

        public  MensajeHelper Mensaje { get; set; }
    }
}