using System.Collections.Generic;
using Framework.MVC;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Presentacion.Models
{
    public class PermisoViewModel : IViewModel
    {
        public Rol Rol { get; set; }

        public IEnumerable<Funcionalidad> Funcionalidades { get; set; }
 

    }
}