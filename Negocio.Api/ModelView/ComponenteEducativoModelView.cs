using Nucleo.Presentacion.Validators;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Api.Models
{

    public class ComponenteEducativoModelView
    {
        [Obligado]
        public int Id { get; set; }
                
        [Obligado]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        [Obligado]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

    }

}