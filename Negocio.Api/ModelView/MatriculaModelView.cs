using Nucleo.Presentacion.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Api.Models
{

    public class MatriculaModelView
    {
        public int Id { get; set; }

        [Obligado]
        public int EstudianteId { get; set; }
        
        [Display(Name = "Estudiante")]
        public string EstudianteNombre { get; set; }

        [Obligado]
        public int ComponenteEducativoId { get; set; }

        [Display(Name = "Componente Educativo")]
        public string ComponenteEducativoNombre { get; set; }

    }

}