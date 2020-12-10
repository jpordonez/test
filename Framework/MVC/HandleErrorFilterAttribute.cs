using System.Web.Mvc;
using Framework.Exception;
using Microsoft.Practices.ServiceLocation;

namespace Framework.MVC
{
    /// <summary>
    /// Filtro para manejar las excepciones, en el caso de ser ajax se pasa un json con la información del error
    /// </summary>
    public class HandleErrorFilterAttribute : HandleErrorAttribute
    {
        //private static ErrorFilterConfiguration _config;

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            if (!filterContext.ExceptionHandled)
                return;

            var manejadorExcepciones = ServiceLocator.Current.GetInstance<IHandlerExcepciones>();

            var _exceptionResult = manejadorExcepciones.HandleException(filterContext.Exception);

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = new JsonResult
                {
                    Data = new { error = _exceptionResult.Message },
                    //ContentType = contentType,
                    //ContentEncoding = contentEncoding,
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };

                //result.
                filterContext.Result = result;
            }

            //base.OnException(context);

            //if (!context.ExceptionHandled) // if unhandled, will be logged anyhow
            //    return;

            //var e = context.Exception;
            //var httpContext = context.HttpContext.ApplicationInstance.Context;
            //if (httpContext != null &&
            //    (RaiseErrorSignal(e, httpContext) // prefer signaling, if possible
            //     || IsFiltered(e, httpContext))) // filtered?
            //    return;

            //LogException(e, httpContext);

        }
    }
}
