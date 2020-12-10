using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;

namespace Nucleo.Presentacion.Helpers
{
     public static class SecurityExtensions
    {

         /// <summary>
         /// Verificar si existe una autentificacion activa 
         /// </summary>
         /// <param name="htmlHelper"></param>
         /// <returns></returns>
         public static bool IsAuthenticated(this HtmlHelper htmlHelper)
         {
             var app = ServiceLocator.Current.GetInstance<IApplication>();

             return app.IsAuthenticated();
         }
    }
}
