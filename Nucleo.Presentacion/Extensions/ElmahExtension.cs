using System.Web;
using Elmah;
using Framework.Extensions;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;
using System;

namespace Nucleo.Presentacion
{


    /// <summary>
    /// Wrapper Elmah para asp.net, wcf
    /// </summary>
    public class ElmahExtension : IElmahExtension
    {
        public void LogToElmah(System.Exception ex)
        {
            /*if (HttpContext.Current != null && HttpContext.Current.ApplicationInstance != null)
            {
                //TODO: Existe un problema a pesar que HttpContext.Current, el HttpContext.Current.ApplicationInstance  es nulo
                //HttpContext.Current.ApplicationInstance 
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            else
            {
                //TODO: JSA, REVISAR COMO APLICAR ELMAH EN CONSOLA, OPCION 1 NO REGISTRA SEGUN EL CORREO PERMITE ENVIAR CORREOS, LA OPCION 2 REGISTRA EN LA BASE DE DATOS
                //INVESTIGAR 
                //http://stackoverflow.com/questions/841451/using-elmah-in-a-console-application

                //OPCION 1
                //if (httpApplication == null) InitNoContext();
                //ErrorSignal.Get(httpApplication).Raise(ex);

                //OPCION 2
                ErrorLog errorLog = ErrorLog.GetDefault(null);
                //TODO: Configurar el nombre de la aplicacion
                errorLog.ApplicationName = "Farmaline"; // ErrorHandling.Application;
                var error = new Elmah.Error(ex);
                var app = ServiceLocator.Current.GetInstance<IApplication>();
                error.User = app?.GetCurrentUser()?.Cuenta;
                errorLog.Log(error);
            }*/
            
            ErrorLog errorLog = ErrorLog.GetDefault(null);
            //TODO: Configurar el nombre de la aplicacion
            errorLog.ApplicationName = "Farmaline"; // ErrorHandling.Application;
            var error = new Elmah.Error(ex);
            var app = ServiceLocator.Current.GetInstance<IApplication>();
            Usuario usuario = null;
            try
            {
                usuario = app?.GetCurrentUser();
            }
            catch (Exception e)
            {
            }            

            error.User = usuario?.Cuenta;
            errorLog.Log(error);
        }


    }
}
