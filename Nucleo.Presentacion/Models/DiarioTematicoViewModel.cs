using System.ComponentModel.DataAnnotations;
using Nucleo.Presentacion.Validators;

namespace Nucleo.Presentacion.Models
{
    public class DiarioTematicoViewModel
    {
        [Obligado]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public string Asignatura { get; set; }
        public string FechaDeSesionClase { get; set; }
        public int? DiarioTematicoId { get; set; }
        public string FechaClase { get; set; }
        public string AgendaIds { get; set; }
        public int Nrc { get; set; }
        public string Curso { get; set; }
        public string Periodo { get; set; }
        public string IdentificadorCurso { get; set; }
    }
}