using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Framework.Logging;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Nucleo.Dominio.Entidades;
using Framework.Util;

namespace Nucleo.Presentacion.Filters
{
    /// <summary>
    /// Metodos de ayuda para mapear el mecanismo de seguridad del SGA a controles de MVC
    /// </summary>
    public class SecurityControllerHelper
    {

        static readonly ILogger log =
           ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(SecurityControllerHelper));


        /// <summary>
        /// Listado de prefijos de acciones que no se debe aplicar autorizacion
        /// </summary>
        private static List<string> _ListSkipAction;
        private static List<string> ListSkipAction
        {
            get
            {
                if (_ListSkipAction == null)
                {
                    //Acciones que se debe omitir no se debe aplicar autorizacion
                    var mapperOmitir = AppSettings.Get<string>("Seguridad.Acciones.Omitir");
                    _ListSkipAction = new List<string>();
                    foreach (var i in mapperOmitir.Split(','))
                    {
                        _ListSkipAction.Add(i.ToUpper());
                    }

                }
                return _ListSkipAction;
            }
        }


        /// <summary>
        /// Listado de controladores que se deben omitir
        /// </summary>
        private static List<string> _ListSkipController;
        private static List<string> ListSkipController
        {
            get
            {
                if (_ListSkipController == null)
                {
                    var controllerSkip = AppSettings.Get<string>("Seguridad.Controladores.Omitir");
                    _ListSkipController = new List<string>();
                    foreach (var i in controllerSkip.Split(','))
                    {
                        _ListSkipController.Add(i.ToUpper());
                    }

                }
                return _ListSkipController;
            }
        }




        private static HashSet<KeyValuePair<string, string>> _Mapper;
        private static HashSet<KeyValuePair<string, string>> Mapper
        {
            get
            {
                if (_Mapper == null)
                {

                    var mapperSinonimos = AppSettings.Get<string>("Seguridad.Acciones.Sinonimos");

                    Dictionary<string, string> listaSinomios = JsonConvert.DeserializeObject<Dictionary<string, string>>(mapperSinonimos);

                    _Mapper = new HashSet<KeyValuePair<string, string>>();

                    foreach (var item in listaSinomios)
                    {

                        foreach (var sinonimo in item.Value.Split(','))
                        {
                            if (string.IsNullOrWhiteSpace(sinonimo) || string.IsNullOrWhiteSpace(item.Key))
                                continue;
                            _Mapper.Add(new KeyValuePair<string, string>(sinonimo, item.Key));
                        }

                    }
                }
                return _Mapper;
            }
        }


        /// <summary>
        /// Obtener funcionalidades desde la informacion del controlador
        /// </summary>
        /// <param name="funcionalidades"></param>
        /// <param name="controllerDescriptor"></param>
        /// <returns></returns>
        public static Funcionalidad ControllerToFunctionality(IEnumerable<Funcionalidad> funcionalidades,
            ControllerDescriptor controllerDescriptor)
        {
            //TODO: JSA. SE PUEDE MEJORAR SE CREA UN MAPPER (NOMBRE CONTROLLAR, FUNCIONALIDAD)

            //Buscar funcionalidades que tenga el nombre del controlador
            var funcionalidadesRelControlador = from f in funcionalidades
                                                where (f.Controlador.ToUpper().Equals(controllerDescriptor.ControllerName.ToUpper()))
                                                select f;

            var list = funcionalidadesRelControlador.ToList();

            log.DebugFormat("Resultado de convertir nombre de controlador : [{0}] a funcionalidad del sistema : [{1}], cantidad de resultados que coincide : [{2}]", controllerDescriptor.ControllerName.ToUpper(), (list.Count == 1 ? list[0].Nombre : ""), list.Count.ToString());

            if (list.Count == 0)
                return null;

            if (list.Count > 1)
            {
                //No puede existir varias funcionalidades mapeadas al mismo controlador ??? 
                throw new Exception(string.Format("Existe varias funcionalidades mapeadas al controlador [{0}], un total de [{1}]", controllerDescriptor.ControllerName, list.Count));

            }

            return list[0];
        }

        /// <summary>
        /// Mapear las acciones de un controlador MVC con las acciones de Seguridad
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public static Accion ActionControllerToActionFunctionality(Funcionalidad funcionalidad, ActionDescriptor actionDescriptor)
        {

            string accion = string.Empty;

            var listAction = from i in Mapper
                             where actionDescriptor.ActionName.StartsWith(i.Key, StringComparison.OrdinalIgnoreCase)
                             select i;

            if (listAction.Count() == 1)
                accion = listAction.ToList()[0].Value;

            if (listAction.Count() > 1)
                throw new Exception(string.Format("Existe varias coincidencias entre el nombre de la accion [{0}], al mapper con las acciones de la funcionalidad [{1}-{2}]", actionDescriptor.ActionName, funcionalidad.Codigo, funcionalidad.Nombre));

            var listAccionesFuncionalidad = from i in funcionalidad.Acciones
                                            where actionDescriptor.ActionName.StartsWith(i.Codigo, StringComparison.OrdinalIgnoreCase) ||
                                            accion.StartsWith(i.Codigo, StringComparison.OrdinalIgnoreCase)
                                            select i;
            if (listAccionesFuncionalidad.Count() == 1)
                return listAccionesFuncionalidad.ToList()[0];

            if (listAccionesFuncionalidad.Count() > 1)
                throw new Exception(string.Format("Existe varias coincidencias entre el nombre de la accion MVC [{0}], al mapper con las acciones de la funcionalidad [{1}-{2}]", actionDescriptor.ActionName, funcionalidad.Codigo, funcionalidad.Nombre));


            // if (list.Count() == 0)
            throw new Exception(string.Format("No existe coincidencias entre el nombre de la accion MVC [{0}], al mapper con las acciones de la funcionalidad [{1}-{2}] ", actionDescriptor.ActionName, funcionalidad.Codigo, funcionalidad.Nombre));


        }


        /// <summary>
        /// Si la acion no es considerada en la verificacion de autorizacion. Ejemplo Validar<Regla>, acciones para validaciones remotadas
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public static bool SkipActionSecurity(ActionDescriptor actionDescriptor)
        {

            var filter = from i in ListSkipAction
                         where actionDescriptor.ActionName.StartsWith(i, StringComparison.OrdinalIgnoreCase)
                         select i;

            var list = filter.ToList();

            log.DebugFormat("Resultado de omitir action : [{0}]. Cantidad de elementos que coincide con la accion desde el listado de omitidos : [{1}]", actionDescriptor.ActionName, list.Count);

            return (list.Count > 0);

        }

        /// <summary>
        /// Si el controlador no se debe aplicar autorizacion. Ejemplo pagina de inicio del sitio web.
        /// </summary>
        /// <param name="controllerDescriptor"></param>
        /// <returns></returns>
        public static bool SkipControllerSecurity(ControllerDescriptor controllerDescriptor)
        {

            var filter = from i in ListSkipController
                         where controllerDescriptor.ControllerName.Equals(i, StringComparison.OrdinalIgnoreCase)
                         select i;

            var list = filter.ToList();

            log.DebugFormat("Resultado de omitir controladores : [{0}]. Cantidad de elementos que coincide con la nombre  de controlador desde el listado de omitidos : [{1}]", controllerDescriptor.ControllerName, list.Count);

            return (list.Count > 0);
        }

    }
}