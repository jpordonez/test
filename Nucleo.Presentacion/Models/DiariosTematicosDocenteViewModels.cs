using System.Collections.Generic;
using Nucleo.Presentacion.Helpers;

namespace Nucleo.Presentacion.Models
{
    public class DiariosTematicosDocenteViewModels
    {
        public DiariosTematicosDocenteViewModels()
        {
            DiariosTematicosDocente = new List<DiarioTematicoViewModel>();
            Mensajes = new List<MensajeHelper>();
        }
        public IList<DiarioTematicoViewModel> DiariosTematicosDocente { get; set; }
        public IEnumerable<MensajeHelper> Mensajes { get; set; }
    }
}