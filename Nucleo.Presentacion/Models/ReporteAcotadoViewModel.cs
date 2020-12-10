using System;
using System.ComponentModel.DataAnnotations;
using Nucleo.Dominio.Recursos;
using Nucleo.Presentacion.Validators;

namespace Nucleo.Presentacion.Models
{
    public class ReporteAcotadoViewModel
    {
        [Obligado]
        [Fecha]
        [Display(ResourceType = typeof(Titulos), Name = "ReporteAcotadoViewModel_FechaInicio_DisplayName")]
        public DateTime FechaInicio { get; set; }

        [Obligado]
        [Fecha]
        [Display(ResourceType = typeof(Titulos), Name = "ReporteAcotadoViewModel_FechaFin_DisplayName")]
        public DateTime FechaFin { get; set; }
    }
}