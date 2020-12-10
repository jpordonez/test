using Negocio.Dominio.Criteria;
using Negocio.Dominio.Models;
using Negocio.Service;
using Nucleo.Dominio;
using Nucleo.Service;
using System;
using System.Linq;
using System.Web.Mvc;
using Negocio.Api.Models;

namespace Negocio.Api.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly IResultadoService _iResultadoService;
        private readonly IMatriculaService _iMatriculaService;
        private readonly IAsignacionDocenteService _iAsignacionDocenteService;
        private readonly IPersonaService _iPersonaService;
        private readonly ICatalogoService _iCatalogoService;
        private readonly IApplication _application;
        private readonly IParametroService _parametroService;

        public ResultadoController(ICatalogoService iCatalogoService,
                                    IApplication application,
                                    IParametroService parametroService,
                                    IPersonaService iPersonaService,
                                    IMatriculaService iMatriculaService,
                                    IAsignacionDocenteService iAsignacionDocenteService,
                                    IResultadoService iResultadoService)
        {
            _iCatalogoService = iCatalogoService;
            _application = application;
            _parametroService = parametroService;
            _iPersonaService = iPersonaService;
            _iResultadoService = iResultadoService;
            _iMatriculaService = iMatriculaService;
            _iAsignacionDocenteService = iAsignacionDocenteService;
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
        public JsonResult Index(ResultadoCriteria criteria)
        {
            var rol = _application.GetCurrentRol();
            var usuario = _application.GetCurrentUser();
            if (rol.EsAdministrador)
            {
                criteria.DocenteId = null;
            }
            else
            {
                criteria.DocenteId = usuario.Id;
            }
            var resulatdo = _iResultadoService.GetList(criteria);
            var vista = (from x in resulatdo.Data
                         orderby x.Fecha descending//,
                         let EstudianteId = x.EstudianteId
                         let EstudianteNombre = x.EstudianteNombre()
                         let DocenteId = x.DocenteId
                         let DocenteNombre = x.DocenteNombre()
                         let ComponenteEducativoId = x.CoeId
                         let ComponenteEducativoCodigo = x.CoeCodigo
                         let ComponenteEducativoNombre = x.CoeNombre
                         let Fecha = x.Fecha.ToString("o")
                         select new
                         {
                             x.Id,
                             EstudianteId,
                             x.EstudianteIdentificacion,
                             EstudianteNombre,
                             DocenteId,
                             DocenteNombre,
                             ComponenteEducativoId,
                             ComponenteEducativoCodigo,
                             ComponenteEducativoNombre,
                             x.AsignacionDocenteId,
                             x.MatriculaId,
                             x.Deberes,
                             x.Examen,
                             x.Promedio,
                             x.Estado,
                             Fecha
                         });

            var resultado = new
            {
                Data = vista,
                resulatdo.TotalPaginas
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Details
        [HttpPost]
        public JsonResult Details(ResultadoModelView model)
        {
            Resultado entidad = _iResultadoService.Get((int)model.Id);
            var vista = new
            {
                entidad.Id,
                EstudianteId = entidad.Matricula.Estudiante.Id,
                EstudianteNombre = entidad.Matricula.Estudiante.ToString(),
                DocenteId = entidad.AsignacionDocente.Docente.Id,
                DocenteNombre = entidad.AsignacionDocente.Docente.ToString(),
                ComponenteEducativoCodigo = entidad.Matricula.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.Matricula.ComponenteEducativo.Nombre,
                entidad.Deberes,
                entidad.Examen,
                entidad.Promedio,
                entidad.Estado,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Create
        [HttpPost]
        public JsonResult Create(ResultadoModelView model)
        {
            var matricula = _iMatriculaService.Get(model.MatriculaId);
            var asignacionDocente = _iAsignacionDocenteService.Get(model.AsignacionDocenteId);
            Resultado entidad = new Resultado();
            entidad.MatriculaId = model.MatriculaId;
            entidad.Matricula = matricula;
            entidad.AsignacionDocenteId = model.AsignacionDocenteId;
            entidad.AsignacionDocente = asignacionDocente;
            entidad.Deberes = model.Deberes;
            entidad.Examen = model.Examen;
            entidad.Fecha = DateTime.Now;
            entidad = _iResultadoService.Guardar(entidad);
            var vista = new
            {
                entidad.Id,
                EstudianteId = entidad.Matricula.Estudiante.Id,
                EstudianteNombre = entidad.Matricula.Estudiante.ToString(),
                ComponenteEducativoCodigo = entidad.Matricula.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.Matricula.ComponenteEducativo.Nombre,
                entidad.Deberes,
                entidad.Examen,
                entidad.Promedio,
                entidad.Estado,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Edit
        [HttpPost]
        public JsonResult Edit(ResultadoModelView model)
        {
            var matricula = _iMatriculaService.Get(model.MatriculaId);
            var asignacionDocente = _iAsignacionDocenteService.Get(model.AsignacionDocenteId);
            Resultado entidad = model.Id.HasValue && model.Id != 0 ? _iResultadoService.Get((int)model.Id) : new Resultado();
            entidad.MatriculaId = model.MatriculaId;
            entidad.Matricula = matricula;
            entidad.AsignacionDocenteId = model.AsignacionDocenteId;
            entidad.AsignacionDocente = asignacionDocente;
            entidad.Deberes = model.Deberes;
            entidad.Examen = model.Examen;
            entidad.Fecha = DateTime.Now;
            entidad = _iResultadoService.Guardar(entidad);
            var vista = new
            {
                entidad.Id,
                EstudianteId = entidad.Matricula.Estudiante.Id,
                EstudianteNombre = entidad.Matricula.Estudiante.ToString(),
                ComponenteEducativoCodigo = entidad.Matricula.ComponenteEducativo.Codigo,
                ComponenteEducativoNombre = entidad.Matricula.ComponenteEducativo.Nombre,
                entidad.Deberes,
                entidad.Examen,
                entidad.Promedio,
                entidad.Estado,
                entidad.Fecha
            };
            return Json(vista, JsonRequestBehavior.AllowGet);
        }

        // POST: AsignacionDocente/Delete/5
        [HttpPost]
        public JsonResult Delete(ResultadoModelView model)
        {
            _iAsignacionDocenteService.Eliminar((int)model.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

}