using System.ComponentModel.DataAnnotations;
using Nucleo.Presentacion.Validators;

namespace Nucleo.Presentacion.Models
{
    public class LoginViewModel
    {
        [Obligado]
        [Display(Name = "Usuario Cuenta")]
        public string Usuario { get; set; }

        [Obligado]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
        public string IPClient { get; set; }
    }
}