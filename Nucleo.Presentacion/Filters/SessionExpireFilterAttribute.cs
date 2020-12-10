using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;

namespace Nucleo.Presentacion.Filters
{
    /// <summary>
    /// Filtro para validar si el usuario se encuentra autorizado
    /// </summary>
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            HttpContext ctx = HttpContext.Current;

            // Verifica si la session es soportada
            if (ctx.Session != null)
            {

                bool isAllowAnonymousAttribute = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

                if (!isAllowAnonymousAttribute)
                {

                    var app = ServiceLocator.Current.GetInstance<IApplication>();
                    if (!app.IsAuthenticated())
                    {

                        //Asegurar eliminar cualquier rastro de autentificacion
                        if (ctx.Request.IsAuthenticated)
                        {
                            ctx.Session.Clear();
                            FormsAuthentication.SignOut();
                        }
                        ctx.Response.Redirect(FormsAuthentication.LoginUrl);
                    }
                }

            }
            base.OnActionExecuting(filterContext);
        }
    }
}