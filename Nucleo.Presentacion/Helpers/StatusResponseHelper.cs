using System;
using System.Web;
using System.Web.Mvc;
using Framework.Exception;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Presentacion.Models;

namespace Nucleo.Presentacion.Helpers
{
    public class StatusResponseHelper
    {
        private static readonly IHandlerExcepciones manejadorExcepciones =
            ServiceLocator.Current.GetInstance<IHandlerExcepciones>();

        public static JsonResult JsonNoAutenticado(string mensaje, bool presentar)
        {
            manejadorExcepciones.HandleException(new GenericException(mensaje, mensaje));
            var result = new JsonResult
            {
                Data = new
                {
                    mensaje,
                    presentar,
                    autenticado = false
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            HttpContext.Current.Response.StatusCode = 401;
            return result;
        }

        public static JsonResult JsonNoAutorizado(string mensaje, bool presentar)
        {
            manejadorExcepciones.HandleException(new GenericException(mensaje, mensaje));
            var result = new JsonResult
            {
                Data = new
                {
                    mensaje,
                    presentar,
                    autenticado = false
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            HttpContext.Current.Response.StatusCode = 403;
            return result;
        }

        public static JsonResult JsonNoSeleccionadoRol(string mensaje, SeleccionarRolViewModel modelRol, object usuarioView, string token)
        {
            manejadorExcepciones.HandleException(new GenericException(mensaje, mensaje));
            var result = new JsonResult
            {
                Data = new
                {
                    mensaje,
                    roles = modelRol.Roles,
                    usuario = usuarioView,
                    miToken = token,
                    autenticado = true
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            //Precondition Failed:
            HttpContext.Current.Response.StatusCode = 412;
            return result;
        }

        public static JsonResult JsonErrorServidor(string mensaje, bool presentar)
        {
            var resultado = manejadorExcepciones.HandleException(new Exception(mensaje));
            var result = new JsonResult
            {
                Data = new
                {
                    mensaje = presentar ? mensaje : resultado.Message,
                    presentar
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            HttpContext.Current.Response.StatusCode = 409;
            return result;
        }

        public static JsonResult JsonIdNulo()
        {
            return JsonErrorServidor("No se ha pasado un id valido (valor nulo).", false); ;
        }

        public static JsonResult JsonNoExiste(int id)
        {
            return JsonErrorServidor("No existe una entidad para el id: " + id, false);
        }

    }
}
