using System.Web.Mvc;
using Framework.MVC;
using Framework.Util;
using Nucleo.Presentacion.Filters;
using Framework.Constantes;

namespace Negocio.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Filtro para controlar las excepciones
            filters.Add(new HandleErrorFilterServicioWebAttribute());


            //Filtro para pedir autentificacion a todos
            filters.Add(new AuthenticationTokenAttribute());
            

            //Filtro para verificar si el usuario mantiene la sesion autentificada
            //filters.Add(new SessionExpireTokenFilterAttribute());


            var aplicarAutorizacion = AppSettings.Get<bool>(ConstantesWebConfig.APLICAR_MECANISMO_AUTORIZACION);
            if (aplicarAutorizacion)
            {
                //Filtro para controla autorizacion del sistema. Basado en los permisos del rol y usuario autentificado
                filters.Add(new AuthorizeFilterServiciosAttribute());
            }
        }
    }
}
