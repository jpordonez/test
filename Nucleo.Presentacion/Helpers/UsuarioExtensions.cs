using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Presentacion.Helpers
{
    public static class UsuarioExtensions
    {
       


        public static string GetIdentityUser(this Usuario usuario)
        {
            var CampoIdentidad = ManagerUser.CampoIdentidad;
            if (CampoIdentidad == CamposIdentidadUsuario.Id)
                return usuario.Id.ToString();

            if (CampoIdentidad == CamposIdentidadUsuario.UserName)
                return usuario.Cuenta;

            return null;
        }


        public static MvcHtmlString GetUserName(this HtmlHelper htmlHelper)
        {
                var application = ServiceLocator.Current.GetInstance<IApplication>();
                var usuario = application.GetCurrentUser();
                if (usuario != null)
                    return MvcHtmlString.Create(usuario.Nombres);

                return MvcHtmlString.Create(string.Empty);
        }


        
    }

    public enum CamposIdentidadUsuario
    {
        Id,
        UserName 
    }

    
}