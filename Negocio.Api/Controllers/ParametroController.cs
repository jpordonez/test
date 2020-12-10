using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Negocio.Api.Models;
using Framework.Exception;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Service;
using Nucleo.Dominio.Criteria;
using Negocio.Dominio.Codigos;

namespace Negocio.Api.Controllers
{
    public class ParametroController : BaseController
    {

        private readonly IParametroService _iParametroService;
        private readonly IApplication _application;

        public ParametroController(IHandlerExcepciones manejadorExcepciones,
            IParametroService iParametroService,
            IApplication application) :
            base(manejadorExcepciones)
        {
            _iParametroService = iParametroService;
            _application = application;
        }

        // GET: Predio
        [HttpGet, ActionName("Get")]
        public JsonResult GetDatosInicio()
        {
            var tipos = new List<object>();
            tipos.Add(new { label = TipoParametro.Numero.ToString(), value = TipoParametro.Numero });
            tipos.Add(new { label = TipoParametro.Cadena.ToString(), value = TipoParametro.Cadena });
            tipos.Add(new { label = TipoParametro.Booleano.ToString(), value = TipoParametro.Booleano });
            tipos.Add(new { label = TipoParametro.Listado.ToString(), value = TipoParametro.Listado });
            tipos.Add(new { label = TipoParametro.Fecha.ToString(), value = TipoParametro.Fecha });
            var parametroDatosInicio = new { tipos };
            return Json(parametroDatosInicio, JsonRequestBehavior.AllowGet);
        }

        // POST: AvaluoParametrizacion
        [HttpPost]
        public JsonResult Index(ParametroCriteria criteria)
        {
            var pageNumber = criteria.NumeroPagina < 1 ? 1 : criteria.NumeroPagina;
            var pageSize = _iParametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);
            var parametros = _iParametroService.GetList()
                .Where(c => string.IsNullOrWhiteSpace(criteria.Nombre) || c.Nombre.ToLower().Contains(criteria.Nombre.ToLower()));
            var inicio = (pageNumber - 1) * pageSize;
            var fin = inicio + pageSize > parametros.Count() ? parametros.Count() - inicio : pageSize;
            var parametrosPagina = parametros.ToList().GetRange(inicio, fin);
            var parametrosVista = (from x in parametrosPagina
                                  let Opciones = getItems(x.Opciones)
                                  orderby x.Nombre
                                  select new { x.Id, x.Nombre, x.Codigo, x.Descripcion, x.Valor, x.TieneOpciones, x.Tipo, x.EsEditable, x.FechaCreacion, Opciones });
            var resultado = new
            {
                Data = parametrosVista,
                TotalRegistros = parametros.Count()
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<object> getItems(ICollection<ParametroOpcion> items)
        {
            var itemsVista = (from x in items
                              orderby x.Texto
                              select new { x.Id, x.Texto, x.Valor });
            return itemsVista;
        }

        // POST: AvaluoParametrizacion/Details
        [HttpPost]
        public JsonResult Details(int id)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: AvaluoParametrizacion/Edit
        [HttpPost]
        public JsonResult Create(ParametroModeloVista entidad)
        {
            var parametroSistema = new ParametroSistema();
            parametroSistema.Categoria = CategoriaParametro.General;
            parametroSistema.Codigo = entidad.Codigo;
            parametroSistema.Descripcion = entidad.Descripcion;
            parametroSistema.EsEditable = entidad.EsEditable;
            parametroSistema.Nombre = entidad.Nombre;
            parametroSistema.SistemaId = _application.GetCurrentSistema().Id;
            parametroSistema.TieneOpciones = entidad.Opciones.Count > 0;
            parametroSistema.Tipo = entidad.Tipo;
            parametroSistema.Valor = entidad.Valor;
            parametroSistema.Opciones = new List<ParametroOpcion>();
            foreach (var opcion in entidad.Opciones)
            {
                var ap = new ParametroOpcion();
                ap.Texto = opcion.Texto;
                ap.Valor = opcion.Valor;
                parametroSistema.Opciones.Add(ap);
            }
            _iParametroService.SaveOrUpdate(parametroSistema);
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        // POST: AvaluoParametrizacion/Edit
        [HttpPost]
        public JsonResult Edit(ParametroModeloVista entidad)
        {
            var parametroSistema = _iParametroService.Get(entidad.Id);
            parametroSistema.Categoria = CategoriaParametro.General;
            parametroSistema.Codigo = entidad.Codigo;
            parametroSistema.Descripcion = entidad.Descripcion;
            parametroSistema.EsEditable = entidad.EsEditable;
            parametroSistema.Nombre = entidad.Nombre;
            parametroSistema.SistemaId = _application.GetCurrentSistema().Id;
            parametroSistema.Tipo = entidad.Tipo;
            parametroSistema.Valor = entidad.Valor;
            parametroSistema.TieneOpciones = entidad.Opciones.Count > 0;

            //Actualizados
            var actualizados = parametroSistema.Opciones.Where(c => entidad.Opciones.Any(d => c.Id == d.Id));

            foreach (var actualizado in actualizados)
            {
                var elemento = entidad.Opciones.FirstOrDefault(i => i.Id == actualizado.Id);
                if (elemento != null)
                {
                    actualizado.Texto = elemento.Texto;
                    actualizado.Valor = elemento.Valor;
                }
            }

            //Nuevos
            var nuevos = entidad.Opciones.Where(c => c.Id == 0);
            foreach (var nuevo in nuevos)
            {
                var ap = new ParametroOpcion();
                ap.Texto = nuevo.Texto;
                ap.Valor = nuevo.Valor;
                parametroSistema.Opciones.Add(ap);
            }

            //Eliminados
            var eliminados = parametroSistema.Opciones.Where(c => entidad.Opciones.All(d => c.Id != d.Id)).ToList();
            _iParametroService.EliminarOpciones(eliminados);

            _iParametroService.SaveOrUpdate(parametroSistema);
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        // POST: AvaluoParametrizacion/Delete
        [HttpPost]
        public JsonResult Delete(ParametroModeloVista entidad)
        {
            _iParametroService.Eliminar(entidad.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
