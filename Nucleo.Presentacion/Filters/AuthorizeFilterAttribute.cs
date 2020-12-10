using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Service;

namespace Nucleo.Presentacion.Filters
{
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            //1. SISTEMA
            //   1.1 Funcionalidades
            //       1.1.1 Acciones
            //   1.2 Roles
            //       1.2.1 Permisos => Acciones => Funcionalidades
            //   1.3 Menus
            //      1.3.1. Items Menu => Funcionalidad

            //APLICAR AUTORIZACION BASADO EN EL NOMBRE DEL CONTROLADOR
            //controller/accion/parametros
            //{controller}/{action}/{id}
            //Mapear los nombres de los controllers a los menus y estos a las funcionalidades



            if (filterContext == null)
            {
                throw new ArgumentNullException("AuthorizeFilterAttribute");
            }


            //1. Saltar autorizacion, si el controlador o la accion tiene el atributo AllowAnonymousAttribute
            bool isAllowAnonymousAttribute =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
             || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                typeof(AllowAnonymousAttribute), inherit: true);


            if (isAllowAnonymousAttribute)
                return;

            //2. Saltar autorizacion. 
            //2.1 Controladores o acciones que no se debe verificar
            //2.2 Atributos explicitos en los controladores que indica que no se debe verificar la autorizacion

            if (SecurityControllerHelper.SkipControllerSecurity(filterContext.ActionDescriptor.ControllerDescriptor))
            {
                //log.InfoFormat("No aplicar autorización al controllador ", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                return;
            }

            if (SecurityControllerHelper.SkipActionSecurity(filterContext.ActionDescriptor))
            {

                //log.InfoFormat("No aplicar autorización a la action {0} del controller {1}", filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                return;
            }



            HttpContext ctx = HttpContext.Current;
            if (!ctx.Request.IsAuthenticated)
                return;


            //3.  Verifica si la session es soportada y si el existe autentificacion activa
            if (ctx.Session != null)
            {
                var application = ServiceLocator.Current.GetInstance<IApplication>();

                //2.1 Verificar si existe autentificacion no activa en el sistema, y mvc tiene la peticion autentificada.
                //Existe una desface, se debe forzar a salir
                if (!application.IsAuthenticated())
                {
                    //FORZAR A SALIR DE LA APLICACION, EXISTE UN DESFACE ENTRE AUTENTIFICACION EN EL SISTEMA Y AUTENTIFICACION LA PETICION
                    //BORRAR:
                    //var usuario = _application.GetCurrentUser();
                    //_accessService.EndUserAccess(usuario);

                    ////TODO: DEPENDENCIAS DE REINICIAR. MEJOR GUARDAR EN SESSION LA IDENTIDAD 
                    //FormsAuthentication.SignOut();

                    //Session.Clear();
                    //return RedirectToAction("Ingreso");

                    //TODO: JSA QUE PASA CON REQTICIONES AJAX ??? 
                    if (ctx.Request.IsAuthenticated)
                    {
                        ctx.Session.Clear();
                        FormsAuthentication.SignOut();
                    }
                    ctx.Response.Redirect(FormsAuthentication.LoginUrl);
                }
            }


           //TODO: JSA, PARA MEJORAR RENDIMIENTO.. SE DEBE GUARDAR 
           // (Controller/Action => Funcionalidad/accion Asociada), puesto que verifica esta combinacion por cada peticion al sistema. 

           var servicioFuncionalidad = ServiceLocator.Current.GetInstance<IFuncionalidadService>();
 
           var funcionalidadRelacionada = SecurityControllerHelper.ControllerToFunctionality(servicioFuncionalidad.GetFuncionalidades(),
               filterContext.ActionDescriptor.ControllerDescriptor);

           if (funcionalidadRelacionada == null)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var logonUrl = url.Action("NoAutorizado", "Cuenta", new { reason = string.Format("No existe funcionalidades asociadas al controlador {0}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName) });
                filterContext.Result = new RedirectResult(logonUrl);
                return;

            }
            else
            {
                  
                    var accion = SecurityControllerHelper.ActionControllerToActionFunctionality(funcionalidadRelacionada, filterContext.ActionDescriptor);

                    var servicio = ServiceLocator.Current.GetInstance<IAuthorizationService>();
                    if (!servicio.Authorize(accion))
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                            var result = new JsonResult
                            {
                                Data = new { success = false, error = string.Format("Acceso restringido a la funcionalidad [{0}], en la acción de [{1}]", funcionalidadRelacionada.Nombre, accion.Nombre) },
                                //ContentType = contentType,
                                //ContentEncoding = contentEncoding,
                                JsonRequestBehavior = JsonRequestBehavior.DenyGet
                            };

                            filterContext.Result = result;
                            return;
                        }
                        else
                        {

                            var url = new UrlHelper(filterContext.RequestContext);
                            var logonUrl = url.Action("NoAutorizado", "Cuenta", new { reason = string.Format("Acceso restringido a la funcionalidad {0}, en la acción de [{1}]", funcionalidadRelacionada.Nombre, accion.Nombre) });
                            filterContext.Result = new RedirectResult(logonUrl);
                            return;

                        }
                  }
                
            }
        }
    }
}