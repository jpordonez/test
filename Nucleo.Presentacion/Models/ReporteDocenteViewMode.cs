using System.ComponentModel.DataAnnotations;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Presentacion.Models
{

    public class ReporteDocenteViewMode : ReporteAcotadoViewModel
    {
        [Display(ResourceType = typeof(Titulos), Name = "ReporteDocenteViewMode_DocenteId_DisplayName")]
        public virtual string DocenteId { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
    }
}