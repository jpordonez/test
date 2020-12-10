using System.Linq;
using System.Web.Mvc;
using Framework.Exception;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;
using Nucleo.Service;
using System.Collections.Generic;
using Nucleo.Dominio.Criteria;
using Negocio.Dominio.Codigos;

namespace Negocio.Api.Controllers
{
    public class RolController : BaseController
    {

        private readonly IParametroService _iParametroService;
        private readonly IRolService _iRolService;
        private readonly IApplication _application;
        private readonly IFuncionalidadService _funcionalidadService;

        public RolController(IHandlerExcepciones manejadorExcepciones,
            IParametroService iParametroService,
            IApplication application,
            IRolService iRolService,
            IFuncionalidadService funcionalidadService) :
            base(manejadorExcepciones)
        {
            _iParametroService = iParametroService;
            _application = application;
            _iRolService = iRolService;
            _funcionalidadService = funcionalidadService;
        }

        // GET: Rol/Get
        [HttpGet, ActionName("Get")]
        public JsonResult GetDatosInicio()
        {
            var funcionalidades = _funcionalidadService.GetFuncionalidades();

            var funcionalidadesAcciones = new List<object>();
            foreach (var funcionalidad in funcionalidades)
            {
                foreach (var accion in funcionalidad.Acciones)
                {
                    var funAccion = new
                    {
                        value = accion.Id,
                        label = funcionalidad.Nombre + " - " + accion.Nombre
                    };
                    funcionalidadesAcciones.Add(funAccion);
                }
            }
            var result = new JsonResult
            {
                Data = new
                {
                    funcionalidadesAcciones
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        // POST: Rol/Index
        [HttpPost]
        public JsonResult Index(ParametroCriteria criteria)
        {
            var pageNumber = criteria.NumeroPagina < 1 ? 1 : criteria.NumeroPagina;
            var pageSize = _iParametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);
            var roles = _iRolService.GetList()
                .Where(c => string.IsNullOrWhiteSpace(criteria.Nombre) || c.Nombre.ToLower().Contains(criteria.Nombre.ToLower()));
            var inicio = (pageNumber - 1) * pageSize;
            var fin = inicio + pageSize > roles.Count() ? roles.Count() - inicio : pageSize;
            var rolesPagina = roles.ToList().GetRange(inicio, fin);
            var rolesVista = (from x in rolesPagina
                              let Permisos = getPermisos(x.Permisos)
                              orderby x.Nombre
                              select new { x.Id, x.Nombre, x.Codigo, x.EsAdministrador, x.EsExterno, x.Url, x.Parametros, Permisos });
            var resultado = new
            {
                Data = rolesVista,
                TotalRegistros = roles.Count()
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<object> getPermisos(ICollection<Permiso> permisos)
        {
            var itemsVista = (from x in permisos
                              orderby x.Id
                              select new
                              {
                                  x.Id,
                                  x.AccionId,
                                  x.NoVisualizarEnMenu
                              });
            return itemsVista;
        }

        // POST: Rol/Details
        [HttpPost]
        public JsonResult Details(int id)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Rol/Create
        [HttpPost]
        public JsonResult Create(Rol entidad)
        {
            var rol = _iRolService.SaveOrUpdate(entidad);
            var rolVista = new
            {
                rol.Id,
                rol.Codigo,
                rol.Nombre,
                rol.EsAdministrador,
                rol.EsExterno,
                rol.Url
            };
            return Json(rolVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Rol/Edit
        [HttpPost]
        public JsonResult Edit(Rol entidad)
        {
            var rol = _iRolService.Get(entidad.Id);
            rol.Codigo = entidad.Codigo;
            rol.Nombre = entidad.Nombre;
            rol.EsAdministrador = entidad.EsAdministrador;
            rol.EsExterno = entidad.EsExterno;
            rol.Url = entidad.Url;
            rol.Parametros = entidad.Parametros;

            //Actualizados
            var actualizados = rol.Permisos.Where(c => entidad.Permisos.Any(d => c.Id == d.Id));

            foreach (var actualizado in actualizados)
            {
                var elemento = entidad.Permisos.FirstOrDefault(i => i.Id == actualizado.Id);
                if (elemento != null)
                {
                    actualizado.AccionId = elemento.AccionId;
                    actualizado.NoVisualizarEnMenu = elemento.NoVisualizarEnMenu;
                }
            }

            //Nuevos
            var nuevos = entidad.Permisos.Where(c => c.Id == 0);
            foreach (var nuevo in nuevos)
            {
                rol.Permisos.Add(nuevo);
            }

            //Eliminados
            var eliminados = rol.Permisos.Where(c => entidad.Permisos.All(d => c.Id != d.Id)).ToList();
            _iRolService.EliminarPermisos(eliminados);

            rol = _iRolService.SaveOrUpdate(rol);
            var rolVista = new
            {
                rol.Id,
                rol.Codigo,
                rol.Nombre,
                rol.EsAdministrador,
                rol.EsExterno,
                rol.Url
            };
            return Json(rolVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Rol/Delete
        [HttpPost]
        public JsonResult Delete(Rol entidad)
        {
            _iRolService.Eliminar(entidad.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
