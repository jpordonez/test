using Framework.Security;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using System;

namespace Nucleo.Presentacion.Security
{
    /// <summary>
    /// Clase para gestion de identidades de usuarios
    /// </summary>
    public class IdentityUserServiciosWeb : IIdentityUser
    {

        /// <summary>
        /// Obtener el identificador de la identidad del usuario
        /// </summary>
        /// <returns></returns>
        public int GetCurrentIdentity()
        {
            var app = ServiceLocator.Current.GetInstance<IApplication>();
            try
            {
                IUsuario usuario = app.GetCurrentUser();
                return usuario.Id;
            }
            catch (Exception)
            {
                //Si se trata de un usuario anonimo
                return -1;
            }

        }
    }
}
