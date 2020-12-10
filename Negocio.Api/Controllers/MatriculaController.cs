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
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _iMatriculaService;
        private readonly IComponenteEducativoService _iComponenteEducativoService;
        private readonly IPersonaService _iPersonaService;
        private readonly IApplication _application;

        public MatriculaController(IMatriculaService iMatriculaService,
            IComponenteEducativoService iComponenteEducativoService,
            IPersonaService iPersonaService,
                                    IApplication application)
        {
            _iMatriculaService = iMatriculaService;
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
            var criteria = new MatriculaCriteria();
            var rol = _application.GetCurrentRol();
            var usuario = _application.GetCurrentUser();
            if (rol.EsAdministrador)
            {
                criteria.EstudianteId = null;
            }
            else {
                criteria.EstudianteId = usuario.Id;
            }
            var resulatdo = _iMatriculaService.GetList(criteria);
            var vista = (from x in resulatdo
                                    orderby x.Fecha descending//,
                                    let EstudianteId = x.EstudianteId
                                    let EstudianteNombre = x.Estudiante.ToString()
                                    let ComponenteEducativoId = x.ComponenteEducativoId
                                    let ComponenteEducativoCodigo = x.ComponenteEducativo.Codigo
                                    let ComponenteEducativoNombre = x.ComponenteEducativo.Nombre
                                    let Fecha = x.Fecha.ToString("o")
                                    select new
                                    {
                                        x.Id,
                                        EstudianteId,
                                        EstudianteNombre,
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

        // POST: Matricula/Details
        [HttpPost]
        public JsonResult Details(MatriculaModelView model)
        {
            Matricula entidad = _iMatriculaService.Get(model.Id);
            var institucionVista = new
            {
                entidad.Id,
                EstudianteNombre = entidad.Estudiante.ToString(),
                ComponenteEducativoCodigo = entidad.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.ComponenteEducativo.Nombre,
                entidad.Fecha
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Matricula/Create
        [HttpPost]
        public JsonResult Create(MatriculaModelView model)
        {
            var estudiante = _iPersonaService.Get(model.EstudianteId);
            var coe = _iComponenteEducativoService.Get(model.ComponenteEducativoId);
            Matricula entidad = new Matricula();
            entidad.ComponenteEducativoId = model.ComponenteEducativoId;
            entidad.ComponenteEducativo = coe;
            entidad.EstudianteId = model.EstudianteId;
            entidad.Estudiante = estudiante;
            entidad.Fecha = DateTime.Now;
            entidad = _iMatriculaService.Guardar(entidad);
            var vista = new
            {
                entidad.Id,
                EstudianteNombre = entidad.Estudiante.ToString(),
                ComponenteEducativoCodigo = entidad.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.ComponenteEducativo.Nombre,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: Matricula/Edit
        [HttpPost]
        public JsonResult Edit(MatriculaModelView model)
        {
            Matricula entidad = _iMatriculaService.Get(model.Id);
            entidad.ComponenteEducativoId = model.ComponenteEducativoId;
            entidad.EstudianteId = model.EstudianteId;
            entidad.Fecha = DateTime.Now;
            entidad = _iMatriculaService.Guardar(entidad);
            var vista = new
            {
                entidad.Id,
                EstudianteNombre = entidad.Estudiante.ToString(),
                ComponenteEducativoCodigo = entidad.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.ComponenteEducativo.Nombre,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: Matricula/Delete/5
        [HttpPost]
        public JsonResult Delete(Matricula _entidad)
        {
            _iMatriculaService.Eliminar(_entidad.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

}