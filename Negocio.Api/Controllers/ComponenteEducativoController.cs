using Negocio.Dominio.Criteria;
using Negocio.Dominio.Models;
using Negocio.Service;
using Nucleo.Dominio;
using Nucleo.Service;
using System.Linq;
using System.Web.Mvc;

namespace Negocio.Api.Controllers
{
    public class ComponenteEducativoController : Controller
    {
        private readonly IComponenteEducativoService _iComponenteEducativoService;
        private readonly IApplication _application;

        public ComponenteEducativoController(IComponenteEducativoService iComponenteEducativoService,
                                    IApplication application)
        {
            _iComponenteEducativoService = iComponenteEducativoService;
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
            var resulatdo = _iComponenteEducativoService.GetList();
            var vista = (from x in resulatdo
                                    orderby x.Nombre
                                    select new
                                    {
                                        x.Id,
                                        x.Codigo,
                                        x.Nombre
                                    });

            var resultado = new
            {
                Data = vista,
                resulatdo.Count
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // POST: ComponenteEducativo/Details
        [HttpPost]
        public JsonResult Details(ComponenteEducativo entidad)
        {
            entidad = _iComponenteEducativoService.Get(entidad.Id);
            var institucionVista = new
            {
                entidad.Id,                
                entidad.Codigo,
                entidad.Nombre
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: ComponenteEducativo/Create
        [HttpPost]
        public JsonResult Create(ComponenteEducativo entidad)
        {
            entidad = _iComponenteEducativoService.Guardar(entidad);
            var institucionVista = new
            {
                entidad.Id,
                entidad.Codigo,
                entidad.Nombre
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: ComponenteEducativo/Edit
        [HttpPost]
        public JsonResult Edit(ComponenteEducativo _entidad)
        {
            ComponenteEducativo entidad = _iComponenteEducativoService.Get(_entidad.Id);
            entidad.Codigo = entidad.Codigo;
            entidad.Nombre = entidad.Nombre;           
            entidad = _iComponenteEducativoService.Guardar(entidad);
            var institucionVista = new
            {
                entidad.Id,
                entidad.Codigo,
                entidad.Nombre
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: ComponenteEducativo/Delete/5
        [HttpPost]
        public JsonResult Delete(ComponenteEducativo _entidad)
        {
            _iComponenteEducativoService.Eliminar(_entidad.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

}