using Nucleo.Presentacion.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Api.Models
{

    public class AsignacionDocenteModelView
    {
        public int Id { get; set; }

        [Obligado]
        public int DocenteId { get; set; }
        
        [Display(Name = "Docente")]
        public string DocenteNombre { get; set; }

        [Obligado]
        public int ComponenteEducativoId { get; set; }

        [Display(Name = "Componente Educativo")]
        public string ComponenteEducativoNombre { get; set; }

    }

}