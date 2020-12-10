using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Framework.Exception;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Service;

namespace Negocio.Api.Controllers
{
    public class SesionController : BaseController
    {

        private readonly IUsuarioService _iUsuarioService;
        private readonly ISesionService _iSesionService;
        private readonly IApplication _application;

        public SesionController(IHandlerExcepciones manejadorExcepciones,
            IApplication application,
            ISesionService iSesionService,
            IUsuarioService iUsuarioService) :
            base(manejadorExcepciones)
        {
            _application = application;
            _iSesionService = iSesionService;
            _iUsuarioService = iUsuarioService;
        }

        // GET: Sesion/Get
        [HttpGet, ActionName("Get")]
        public JsonResult GetDatosInicio()
        {
            var rolesSistema = _iUsuarioService.GetRolesSistema();
            var rolesSistemaModeloVista = new List<object>();
            foreach (var rs in rolesSistema)
            {
                var rol = new
                {
                    value = rs.Id,
                    label = rs.Nombre,
                    rs.Codigo
                };
                rolesSistemaModeloVista.Add(rol);
            }
            var result = new JsonResult
            {
                Data = new
                {
                    rolesSistemaModeloVista
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        // POST: Sesion/Index
        [HttpPost]
        public JsonResult Index(SesionCriteria criteria)
        {
            var resulatdo = _iSesionService.GetList(criteria);
            var sesionesVista = (from x in resulatdo.Data
                             let Estado = x.EstadoId.ToString()
                             select new
                             {
                                 x.Id,
                                 x.Cuenta,
                                 Inicio = x.Inicio.ToString("o"),
                                 Fin = x.Fin?.ToString("o"),
                                 x.Ip,
                                 x.RolId,
                                 x.Rol,
                                 x.EstadoId,
                                 Estado
                             });
            var resultado = new
            {
                Data = sesionesVista,
                resulatdo.TotalRegistros
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // POST: Sesion/Details
        [HttpPost]
        public JsonResult Details(int id)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Sesion/Edit
        [HttpPost]
        public JsonResult Create()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Sesion/Edit
        [HttpPost]
        public JsonResult Edit()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Sesion/Delete
        [HttpPost]
        public JsonResult Delete()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
