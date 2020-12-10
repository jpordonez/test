using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Framework.Exception;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Presentacion.Helpers;
using Nucleo.Service;
using Nucleo.Dominio.Criteria;
using Negocio.Dominio.Codigos;

namespace Negocio.Api.Controllers
{
    public class CatalogoController : BaseController
    {

        private ICatalogoService _catalogoService;
        private IApplication _application;
        private readonly IParametroService _parametroService;

        public CatalogoController(IHandlerExcepciones manejadorExcepciones,
                                    ICatalogoService catalogoService,
                                    IApplication application,
                                    IParametroService parametroService)
            : base(manejadorExcepciones)
        {
            _catalogoService = catalogoService;
            _application = application;
            _parametroService = parametroService;
        }

        // POST: Catalogo
        [HttpPost]
        public JsonResult Index(CatalogoCriteria catalogoCriteria)
        {
            var pageNumber = catalogoCriteria.NumeroPagina < 1 ? 1 : catalogoCriteria.NumeroPagina;
            var pageSize = _parametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);
            var catalogos = _catalogoService.GetList()
                .Where(c => catalogoCriteria.Nombre == null || catalogoCriteria.Nombre.IsEmpty() || c.Nombre.ToLower().Contains(catalogoCriteria.Nombre.ToLower()));
            var inicio = (pageNumber - 1) * pageSize;
            var fin = inicio + pageSize > catalogos.Count() ? catalogos.Count() - inicio : pageSize;
            var catalogosPagina = catalogos.ToList().GetRange(inicio, fin);
            var catalogosVista = (from x in catalogosPagina
                                  let FechaCreacion = x.FechaCreacion.ToString("o")
                                  let Items = getItems(x.Items)
                                  orderby x.Nombre
                                  select new { x.Id, x.Nombre, x.Codigo, x.Descripcion, FechaCreacion, Items });
            var resultado = new
            {
                Data = catalogosVista,
                TotalRegistros = catalogos.Count()
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<object> getItems(ICollection<ItemCatalogo> items)
        {
            var itemsVista = (from x in items
                              let FechaCreacion = x.FechaCreacion.ToString("o")
                              orderby x.Nombre
                              select new { x.Id, x.CatalogoId, x.CodigoCatalogo, x.Nombre, x.Codigo, x.Descripcion, FechaCreacion });
            return itemsVista;
        }

        // GET: Catalogo/Details/5
        [HttpPost]
        public JsonResult Details(Catalogo catalogoEntrada)
        {
            if (catalogoEntrada.Id == 0)
            {
                return StatusResponseHelper.JsonIdNulo();
            }
            Catalogo catalogo = _catalogoService.Get(catalogoEntrada.Id);
            if (catalogo == null)
            {
                return StatusResponseHelper.JsonNoExiste(catalogoEntrada.Id);
            }
            var catalogoVista = new
            {
                catalogo.Id,
                catalogo.Codigo,
                catalogo.Nombre,
                catalogo.Descripcion,
                catalogo.FechaCreacion,
                Items = getItems(catalogo.Items)
            };
            return Json(catalogoVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Catalogo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(Catalogo catalogo)
        {
            try
            {
                catalogo.SistemaId = _application.GetCurrentSistema().Id;
                foreach (var item in catalogo.Items)
                {
                    item.CodigoCatalogo = catalogo.Codigo;
                    item.Estado = true;
                }
                _catalogoService.Guardar(catalogo, new List<ItemCatalogo>());

                var catalogoVista = new
                {
                    catalogo.Id,
                    catalogo.Codigo,
                    catalogo.Nombre,
                    catalogo.Descripcion,
                    catalogo.FechaCreacion,
                    Items = getItems(catalogo.Items)
                };

                var result = new JsonResult
                {
                    Data = catalogoVista,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return result;
            }
            catch (Exception ex)
            {
                var result = ManejadorExcepciones.HandleException(ex);
                return StatusResponseHelper.JsonErrorServidor(result.Message, true);
            }

        }

        // GET: Catalogo/Edit/5
        public JsonResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusResponseHelper.JsonIdNulo();
            }
            Catalogo entidad = _catalogoService.Get(id.Value);
            if (entidad == null)
            {
                return StatusResponseHelper.JsonNoExiste(id.Value);
            }
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        // POST: Catalogo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(Catalogo entidad)
        {
            var catalogo = _catalogoService.Get(entidad.Id);
            catalogo.Codigo = entidad.Codigo;
            catalogo.Nombre = entidad.Nombre;
            catalogo.Descripcion = entidad.Descripcion;

            //Actualizados
            var actualizados = catalogo.Items.Where(c => entidad.Items.Any(d => c.Id == d.Id));

            foreach (var actualizado in actualizados)
            {
                var elemento = entidad.Items.FirstOrDefault(i => i.Id == actualizado.Id);
                if (elemento != null)
                {
                    actualizado.Nombre = elemento.Nombre;
                    actualizado.Codigo = elemento.Codigo;
                    actualizado.Descripcion = elemento.Descripcion;
                    actualizado.CodigoCatalogo = catalogo.Codigo;
                }
            }

            //Nuevos
            var nuevos = entidad.Items.Where(c => c.Id == 0);
            foreach (var nuevo in nuevos)
            {
                nuevo.CodigoCatalogo = catalogo.Codigo;
                nuevo.Estado = true;
                catalogo.Items.Add(nuevo);
            }

            //Eliminados
            var eliminados = catalogo.Items.Where(c => entidad.Items.All(d => c.Id != d.Id)).ToList();

            _catalogoService.Guardar(catalogo, eliminados);

            var catalogoVista = new
            {
                catalogo.Id,
                catalogo.Codigo,
                catalogo.Nombre,
                catalogo.Descripcion,
                catalogo.FechaCreacion,
                Items = getItems(catalogo.Items)
            };

            return Json(catalogoVista, JsonRequestBehavior.AllowGet);
        }

        // GET: Catalogo/Delete/5
        public JsonResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusResponseHelper.JsonIdNulo();
            }
            Catalogo entidad = _catalogoService.Get(id.Value);
            if (entidad == null)
            {
                return StatusResponseHelper.JsonNoExiste(id.Value);
            }
            return Json(entidad, JsonRequestBehavior.AllowGet);
        }

        // POST: Catalogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                _catalogoService.Eliminar(id);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = ManejadorExcepciones.HandleException(ex);
                return StatusResponseHelper.JsonErrorServidor(result.Message, true);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_repository.Dispose();
                //_repositorySistema.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
