using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Framework.MVC;
using Nucleo.Presentacion.Validators;

namespace Nucleo.Presentacion.Models
{
    /// <summary>
    /// Model para el login del usuario
    /// </summary>
    public class IngresoViewModel : IViewModel
    {
        [Obligado]
        [DisplayName("Usuario")]
        [StringLength(60, ErrorMessage = "El {0} debe tener mínimo {2} caracteres y máximo {1} caracteres de longitud", MinimumLength = 1)]
        public string Usuario { get; set; }

        [Obligado]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        /// Ip del Client
        /// </summary>
        public string IPClient { get; set; }

         

        public IngresoViewModel()
        {
            
     
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class SeleccionarRolViewModel : IViewModel
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }

        public string RolCodigo { get; set; }

        public string Token { get; set; }

        public string IPClient { get; set; }

        public List<RolViewModel> Roles { get; set; }

        public SeleccionarRolViewModel() {
            Roles = new List<RolViewModel>();
        }

    }

    public class RolViewModel : IViewModel, IEquatable<RolViewModel>
    {

        public string CodigoRol { get; set; }

        public string NombreRol { get; set; }

        public override int GetHashCode()
        {
            return CodigoRol.GetHashCode();
        }

        public bool Equals(RolViewModel other)
        {
            if (other == null) return false;
            return (this.CodigoRol.Equals(other.CodigoRol));
           
        }
    }
}