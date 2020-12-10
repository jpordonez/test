using System.Linq;
using Framework.Cache;
using Framework.Exception;
using Framework.Logging;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio de autorizacion
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {

        static readonly ILogger log =
         ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(AuthorizationService));

 
        IApplication _application;
        IRepository<Rol> _repository;
        ICacheManager _cacheManager;
        IFuncionalidadService _funcionalidadService;
        IRolService _rolService;

        public AuthorizationService(IApplication application, IRepository<Rol> repository, ICacheManager cacheManager,IFuncionalidadService funcionalidadService,IRolService rolService)
        {
            _application = application;
            _repository = repository;
            _cacheManager = cacheManager;
            _funcionalidadService = funcionalidadService;
            _rolService = rolService;
        }

        public bool Authorize(string funcionalidadCodigo, string actionCodigo)
        {

            //1. Recuperar funcionalides
            var funcionalidades = _funcionalidadService.GetFuncionalidades();

            //2. Recuperar funcionalidad se verificar su autorizacion
            var funcionalidad = funcionalidades.Where(fun => fun.Codigo == funcionalidadCodigo).SingleOrDefault();
            if (funcionalidad == null)
            {
                //TODO: JSA, lanzar excepcion si no existe funcionalidad o retornar que no se encuentra autorizado ?
                log.DebugFormat("No existe la funcionalidad con el codigo [{0}]", funcionalidadCodigo);

                return false;
            }

            var accion = funcionalidad.Acciones.Where(acc => acc.Codigo == actionCodigo).SingleOrDefault();
            if (accion == null)
            {
                //TODO: JSA, lanzar excepcion si no existe accion / funcionalidad o retornar que no se encuentra autorizado ?
                log.DebugFormat("No existe la accion [{0}] en la  funcionalidad con el codigo [{1}]", actionCodigo, funcionalidadCodigo);
                return false;
            }

            return Authorize(accion);
        }



        public bool Authorize(Accion action)
        {
            //Rol Administrador, tiene todos los permisos
            var rol = _application.GetCurrentRol();
            if (rol.EsAdministrador)
            {
                return true;
            }

            //1. Obtener listado de Roles
            var roles = _rolService.GetList();


            //2. Obtener el Rol autentificado de la lista de roles
            var usuario = _application.GetCurrentUser();
            log.DebugFormat("Verificar permiso de la accion {0} en la funcionalidad {1} para el usuario [{2}-{3}]", action.Codigo, "FALTA FUNCIONADALIDAD",
                           usuario.Cuenta, usuario.Nombres);

          
            var rolVerificar = roles.SingleOrDefault(r => r.Codigo == rol.Codigo);

            if (rolVerificar == null) {
                string error = string.Format("No se encuentra el rol con codigo {0} en la lista de roles", rol.Codigo);
                throw new GenericException(error, error);
            }
 
            
            //3. Recuperar Permisos que posee el rol Autentificado
            var permisos =  rolVerificar.Permisos.Where(p => p.AccionId == action.Id);

            if (permisos.ToList().Count > 0)
                return true;

            
            return false;
        }
    }
}
