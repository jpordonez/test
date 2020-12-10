using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Negocio.Api.Models;
using Framework.Exception;
using Framework.MVC;
using Framework.Security;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Entidades;
using Nucleo.Service;
using Negocio.Dominio.Codigos;

namespace Negocio.Api.Controllers
{
    public class FuncionalidadController : BaseController
    {

        private readonly IParametroService _iParametroService;
        private readonly IFuncionalidadService _iFuncionalidadService;
        private readonly IApplication _application;

        public FuncionalidadController(IHandlerExcepciones manejadorExcepciones,
            IParametroService iParametroService, 
            IFuncionalidadService iFuncionalidadService,
            IApplication application) :
            base(manejadorExcepciones)
        {
            _iParametroService = iParametroService;
            _application = application;
            _iFuncionalidadService = iFuncionalidadService;
        }

        // GET: Funcionalidad
        [HttpGet, ActionName("Get")]
        public JsonResult GetDatosInicio()
        {
            var estados = _iFuncionalidadService.GetEstados();
            var datosInicio = new { estados };
            return Json(datosInicio, JsonRequestBehavior.AllowGet);
        }

        // POST: Funcionalidad
        [HttpPost]
        public JsonResult Index(FuncionalidadCriteria criteria)
        {
            var pageNumber = criteria.NumeroPagina < 1 ? 1 : criteria.NumeroPagina;
            var pageSize = _iParametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);
            var funcionalidades = _iFuncionalidadService.GetFuncionalidades()
                .Where(c => string.IsNullOrWhiteSpace(criteria.Nombre) || c.Nombre.ToLower().Contains(criteria.Nombre.ToLower()));
            var inicio = (pageNumber - 1) * pageSize;
            var fin = inicio + pageSize > funcionalidades.Count() ? funcionalidades.Count() - inicio : pageSize;
            var funcionalidadesPagina = funcionalidades.ToList().GetRange(inicio, fin);
            var parametrosVista = (from x in funcionalidadesPagina
                                   let Acciones = getItems(x.Acciones)
                                   let EstadoNombre = x.EstadoId == Estado.Activo? Estado.Activo.ToString():Estado.Inactivo.ToString()
                                   orderby x.Nombre
                                  select new { x.Id, x.Codigo, x.Nombre, x.Controlador, x.Descripcion, x.EstadoId, EstadoNombre, Acciones });
            var resultado = new
            {
                Data = parametrosVista,
                TotalRegistros = funcionalidades.Count()
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<object> getItems(ICollection<Accion> items)
        {
            var itemsVista = (from x in items
                              orderby x.Id
                              select new { x.Id, x.Codigo, x.Nombre });
            return itemsVista;
        }

        // POST: Funcionalidad/Details
        [HttpPost]
        public JsonResult Details(int id)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Funcionalidad/Edit
        [HttpPost]
        public JsonResult Create(FuncionalidadModeloVista entidad)
        {
            var funcionalidad = new Funcionalidad();
            funcionalidad.Codigo = entidad.Codigo;
            funcionalidad.Nombre = entidad.Nombre;
            funcionalidad.Controlador = entidad.Controlador;
            funcionalidad.Descripcion = entidad.Descripcion;
            funcionalidad.EstadoId = entidad.EstadoId;
            funcionalidad.SistemaId = _application.GetCurrentSistema().Id;
            funcionalidad.Acciones = new List<Accion>();
            foreach (var opcion in entidad.Acciones)
            {
                var a = new Accion();
                a.Codigo = opcion.Codigo;
                a.Nombre = opcion.Nombre;
                funcionalidad.Acciones.Add(a);
            }
            _iFuncionalidadService.SaveOrUpdate(funcionalidad);
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        // POST: Funcionalidad/Edit
        [HttpPost]
        public JsonResult Edit(FuncionalidadModeloVista entidad)
        {
            var funcionalidad = _iFuncionalidadService.Get(entidad.Id);
            funcionalidad.Codigo = entidad.Codigo;
            funcionalidad.Nombre = entidad.Nombre;
            funcionalidad.Controlador = entidad.Controlador;
            funcionalidad.Descripcion = entidad.Descripcion;
            funcionalidad.EstadoId = entidad.EstadoId;
            funcionalidad.SistemaId = _application.GetCurrentSistema().Id;

            //Actualizados
            var actualizados = funcionalidad.Acciones.Where(c => entidad.Acciones.Any(d => c.Id == d.Id));

            foreach (var actualizado in actualizados)
            {
                var elemento = entidad.Acciones.FirstOrDefault(i => i.Id == actualizado.Id);
                if (elemento != null)
                {
                    actualizado.Codigo = elemento.Codigo;
                    actualizado.Nombre = elemento.Nombre;
                }
            }

            //Nuevos
            var nuevos = entidad.Acciones.Where(c => c.Id == 0);
            foreach (var nuevo in nuevos)
            {
                var a = new Accion();
                a.Codigo = nuevo.Codigo;
                a.Nombre = nuevo.Nombre;
                funcionalidad.Acciones.Add(a);
            }

            //Eliminados
            var eliminados = funcionalidad.Acciones.Where(c => entidad.Acciones.All(d => c.Id != d.Id)).ToList();
            _iFuncionalidadService.EliminarAcciones(eliminados);

            _iFuncionalidadService.SaveOrUpdate(funcionalidad);
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        // POST: Funcionalidad/Delete
        [HttpPost]
        public JsonResult Delete(FuncionalidadModeloVista entidad)
        {
            _iFuncionalidadService.Eliminar(entidad.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
