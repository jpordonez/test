using Nucleo.Presentacion.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Api.Models
{

    public class ResultadoModelView
    {
        public int? Id { get; set; }

        [Obligado]
        public int MatriculaId { get; set; }

        [Obligado]
        public int AsignacionDocenteId { get; set; }

        [Obligado]
        public int EstudianteId { get; set; }

        [Display(Name = "Estudiante")]
        public string EstudianteNombre { get; set; }

        [Obligado]
        public int DocenteId { get; set; }
        
        [Display(Name = "Docente")]
        public string DocenteNombre { get; set; }

        [Obligado]
        public int ComponenteEducativoId { get; set; }

        [Display(Name = "Componente Educativo")]
        public string ComponenteEducativoNombre { get; set; }

        [Obligado]
        public decimal Deberes { get; set; }

        [Obligado]
        public decimal Examen { get; set; }

    }

}