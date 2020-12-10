using System.Web.Mvc;
using Framework.Exception;
using Microsoft.Practices.ServiceLocation;

namespace Framework.MVC
{
    /// <summary>
    /// Filtro para manejar las excepciones, en el caso de ser ajax se pasa un json con la información del error
    /// </summary>
    public class HandleErrorFilterServicioWebAttribute : HandleErrorAttribute
    {
        //private static ErrorFilterConfiguration _config;

        public override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);

            //if (!filterContext.ExceptionHandled)
            //    return;

            var manejadorExcepciones = ServiceLocator.Current.GetInstance<IHandlerExcepciones>();

            var _exceptionResult = manejadorExcepciones.HandleException(filterContext.Exception);

            var result = new JsonResult
            {
                Data = new
                {
                    mensaje = _exceptionResult.Message,
                    presentar = true
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            filterContext.Result = result;
            //Para indicar que se maneja la excepcion y devolver response personalizado
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 409;

        }
    }
}
