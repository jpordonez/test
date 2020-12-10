using Negocio.Dominio.Constantes;
using Negocio.Dominio.Criteria;
using Negocio.Dominio.Models;
using Negocio.Api.Models;
using Negocio.Service;
using Nucleo.Dominio;
using Nucleo.Service;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Negocio.Api.Controllers
{
    public class AsignacionDocenteController : Controller
    {
        private readonly IAsignacionDocenteService _iAsignacionDocenteService;
        private readonly IComponenteEducativoService _iComponenteEducativoService;
        private readonly IPersonaService _iPersonaService;
        private readonly IApplication _application;

        public AsignacionDocenteController(IAsignacionDocenteService iAsignacionDocenteService,
            IComponenteEducativoService iComponenteEducativoService,
            IPersonaService iPersonaService,
                                    IApplication application)
        {
            _iAsignacionDocenteService = iAsignacionDocenteService;
            _iComponenteEducativoService = iComponenteEducativoService;
            _iPersonaService = iPersonaService;
            _application = application;
        }

        // GET: DatosIniciales
        [HttpGet, ActionName("Get")]
        public JsonResult DatosIniciales()
        {
            /*Recuperar desde catalogo items
            var tiposPregunta = _iCatalogoService.GetItemsCatalogo(ConstantesCatalogos.CAT_TIPO_PREGUNTA);
            List<object> tipos = new List<object>();
            foreach (var ee in tiposPregunta)
            {
                var e = new
                {
                    value = ee.Id,
                    label = ee.Nombre,
                    Codigo = ee.Codigo
                };
                tipos.Add(e);
            }*/

            /*Recuperar desde parametros opcion
            var periodosAcademicos = _parametroService.Get(CodigosParametros.PARAMETRO_PERIODOS_ACADEMICOS);
            List<object> periodos = new List<object>();
            foreach (var op in periodosAcademicos.Opciones)
            {
                var o = new
                {
                    value = op.Id,
                    Codigo = op.Texto,
                    label = op.Valor
                };
                periodos.Add(o);
            }*/

            var result = new JsonResult
            {
                Data = new
                {
                    /*tipos,
                    periodos  */
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        // POST: Resultado
        [HttpPost]
        public JsonResult Index()
        {
            var criteria = new AsignacionDocenteCriteria();
            var rol = _application.GetCurrentRol();
            var usuario = _application.GetCurrentUser();
            if (rol.EsAdministrador)
            {
                criteria.DocenteId = null;
            }
            else {
                criteria.DocenteId = usuario.Id;
            }
            var resulatdo = _iAsignacionDocenteService.GetList(criteria);
            var vista = (from x in resulatdo
                                    orderby x.Fecha descending//,
                                    let DocenteId = x.DocenteId
                                    let DocenteNombre = x.Docente.ToString()
                                    let ComponenteEducativoId = x.ComponenteEducativoId
                                    let ComponenteEducativoCodigo = x.ComponenteEducativo.Codigo
                                    let ComponenteEducativoNombre = x.ComponenteEducativo.Nombre
                                    let Fecha = x.Fecha.ToString("o")
                                    select new
                                    {
                                        x.Id,
                                        DocenteId,
                                        DocenteNombre,
                                        ComponenteEducativoId,
                                        ComponenteEducativoCodigo,
                                        ComponenteEducativoNombre,
                                        Fecha
                                    });

            var resultado = new
            {
                Data = vista,
                resulatdo.Count
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Details
        [HttpPost]
        public JsonResult Details(AsignacionDocenteModelView model)
        {
            AsignacionDocente entidad = _iAsignacionDocenteService.Get(model.Id);
            var vista = new
            {
                entidad.Id,
                EstudianteNombre = entidad.Docente.ToString(),
                ComponenteEducativoCodigo = entidad.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.ComponenteEducativo.Nombre,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Create
        [HttpPost]
        public JsonResult Create(AsignacionDocenteModelView model)
        {
            var docente = _iPersonaService.Get(model.DocenteId);
            var coe = _iComponenteEducativoService.Get(model.ComponenteEducativoId);
            AsignacionDocente entidad = new AsignacionDocente();
            entidad.ComponenteEducativoId = model.ComponenteEducativoId;
            entidad.ComponenteEducativo = coe;
            entidad.DocenteId = model.DocenteId;
            entidad.Docente = docente;
            entidad.Fecha = DateTime.Now;
            entidad = _iAsignacionDocenteService.Guardar(entidad);
            var vista = new
            {
                entidad.Id,
                EstudianteNombre = entidad.Docente.ToString(),
                ComponenteEducativoCodigo = entidad.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.ComponenteEducativo.Nombre,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Edit
        [HttpPost]
        public JsonResult Edit(AsignacionDocenteModelView model)
        {
            AsignacionDocente entidad = _iAsignacionDocenteService.Get(model.Id);
            entidad.ComponenteEducativoId = model.ComponenteEducativoId;
            entidad.DocenteId = model.DocenteId;
            entidad.Fecha = DateTime.Now;
            entidad = _iAsignacionDocenteService.Guardar(entidad);
            var vista = new
            {
                entidad.Id,
                EstudianteNombre = entidad.Docente.ToString(),
                ComponenteEducativoCodigo = entidad.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.ComponenteEducativo.Nombre,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Delete/5
        [HttpPost]
        public JsonResult Delete(AsignacionDocenteModelView model)
        {
            _iAsignacionDocenteService.Eliminar(model.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

}