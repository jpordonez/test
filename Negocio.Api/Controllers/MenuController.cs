using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using MenuItem = Nucleo.Dominio.Menus.MenuItem;
using Menu = Nucleo.Dominio.Menus.Menu;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Service;
using Framework.Exception;
using Nucleo.Dominio.Menus;
using Nucleo.Presentacion.Helpers;
using Nucleo.Dominio.Criterias;
using Negocio.Dominio.Codigos;
using Negocio.Dominio.Constantes;

namespace Negocio.Api.Controllers
{
    public class MenuController : BaseController
    {

        private readonly IMenuService _menuService;
        private readonly IApplication _application;
        private readonly IParametroService _parametroService;
        private readonly ICatalogoService _catalogoService;
        private readonly IFuncionalidadService _funcionalidadService;

        public MenuController(IHandlerExcepciones manejadorExcepciones,
                                    IMenuService menuService,
                                    IApplication application,
                                    IParametroService parametroService,
                                    ICatalogoService catalogoService,
                                    IFuncionalidadService funcionalidadService)
            : base(manejadorExcepciones)
        {
            _menuService = menuService;
            _application = application;
            _parametroService = parametroService;
            _catalogoService = catalogoService;
            _funcionalidadService = funcionalidadService;
        }

        // GET: Cem
        [HttpGet, ActionName("Get")]
        public JsonResult GetDatosInicio()
        {
            var estados = _catalogoService.GetItemsCatalogo(ConstantesCatalogos.CAT_ESTADO_ENTIDAD);
            List<object> ests = new List<object>();
            foreach (var es in estados)
            {
                var estado = new
                {
                    value = es.Id,
                    label = es.Nombre,
                    es.Codigo
                };
                ests.Add(estado);
            }

            var tipoItemMenuContenedor = new { value = TipoItemMenu.Contenedor, label = TipoItemMenu.Contenedor.ToString() };
            var tipoItemMenuItemMenu = new { value = TipoItemMenu.ItemMenu, label = TipoItemMenu.ItemMenu.ToString() };
            var tiposItemMenu = new[] { tipoItemMenuContenedor, tipoItemMenuItemMenu };
            var funcionalidades = _funcionalidadService.GetFuncionalidades();

            var funcionalidads = new List<object>();
            foreach (var funcionalidad in funcionalidades)
            {
                var fun = new
                {
                    value = funcionalidad.Id,
                    label = funcionalidad.Nombre
                };
                funcionalidads.Add(fun);
            }

            var result = new JsonResult
            {
                Data = new
                {
                    ests,
                    tiposItemMenu,
                    funcionalidads
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        // POST: Menu
        [HttpPost]
        public JsonResult Index(MenuCriteria catalogoCriteria)
        {
            var pageNumber = catalogoCriteria.NumeroPagina < 1 ? 1 : catalogoCriteria.NumeroPagina;
            var pageSize = _parametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);
            var menus = _menuService.GetList()
                .Where(c => catalogoCriteria.Nombre == null || catalogoCriteria.Nombre.IsEmpty() || c.Nombre.ToLower().Contains(catalogoCriteria.Nombre.ToLower()));
            var inicio = (pageNumber - 1) * pageSize;
            var fin = inicio + pageSize > menus.Count() ? menus.Count() - inicio : pageSize;
            var menusPagina = menus.ToList().GetRange(inicio, fin);
            var menusVista = (from x in menusPagina
                              let Items = getItems(x.Items)
                              orderby x.Id
                              select new { x.Id, x.Nombre, x.Codigo, x.Descripcion, Items });
            var resultado = new
            {
                Data = menusVista,
                TotalRegistros = menus.Count()
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<object> getItems(ICollection<MenuItem> items)
        {
            var itemsVista = (from x in items
                              let MenuPadreNombre = string.IsNullOrEmpty(x.PadreCodigo) ? string.Empty : _menuService.GetItem(x.PadreCodigo).Nombre
                              let TipoNombre = x.TipoId.ToString()
                              let EstadoNombre = _catalogoService.GetItem((int)x.EstadoId)?.Nombre
                              let FuncionalidadNombre = _funcionalidadService.Get(x.FuncionalidadId ?? 0)?.Nombre
                              orderby x.Nombre
                              select new
                              {
                                  x.Id,
                                  x.Codigo,
                                  x.Descripcion,
                                  x.EstadoId,
                                  x.FuncionalidadId,
                                  x.Icono,
                                  x.Nombre,
                                  x.Orden,
                                  x.PadreCodigo,
                                  MenuPadreNombre,
                                  TipoNombre,
                                  EstadoNombre,
                                  FuncionalidadNombre,
                                  x.TipoId,
                                  x.Url
                              });
            return itemsVista;
        }


        // POST: Menu/Details
        [HttpPost]
        public JsonResult Details(Menu entidad)
        {
            if (entidad.Id == 0)
            {
                return StatusResponseHelper.JsonIdNulo();
            }
            Menu catalogo = _menuService.Get(entidad.Id);
            if (catalogo == null)
            {
                return StatusResponseHelper.JsonNoExiste(entidad.Id);
            }
            var menuVista = new
            {
                catalogo.Id,
                catalogo.Codigo,
                catalogo.Nombre,
                catalogo.Descripcion,
                Items = getItems(catalogo.Items)
            };
            return Json(menuVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Menu/Create
        [HttpPost]
        public JsonResult Create(Menu entidad)
        {
            try
            {
                entidad.SistemaId = _application.GetCurrentSistema().Id;
                _menuService.Guardar(entidad);

                var menuVista = new
                {
                    entidad.Id,
                    entidad.Codigo,
                    entidad.Nombre,
                    entidad.Descripcion,
                    Items = getItems(entidad.Items)
                };

                var result = new JsonResult
                {
                    Data = menuVista,
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

        // POST: Menu/Edit
        [HttpPost]
        public JsonResult Edit(Menu entidad)
        {
            try
            {
                var menu = _menuService.Get(entidad.Id);
                menu.Codigo = entidad.Codigo;
                menu.Nombre = entidad.Nombre;
                menu.Descripcion = entidad.Descripcion;

                //Actualizados
                var actualizados = menu.Items.Where(c => entidad.Items.Any(d => c.Id == d.Id));

                foreach (var actualizado in actualizados)
                {
                    var elemento = entidad.Items.FirstOrDefault(i => i.Id == actualizado.Id);
                    if (elemento != null)
                    {
                        actualizado.Nombre = elemento.Nombre;
                        actualizado.Codigo = elemento.Codigo;
                        actualizado.Descripcion = elemento.Descripcion;
                        actualizado.EstadoId = elemento.EstadoId;
                        actualizado.FuncionalidadId = elemento.FuncionalidadId;
                        actualizado.Icono = elemento.Icono;
                        actualizado.Orden = elemento.Orden;
                        actualizado.PadreCodigo = elemento.PadreCodigo;
                        actualizado.TipoId = elemento.TipoId;
                        actualizado.Url = elemento.Url;
                    }
                }

                //Nuevos
                var nuevos = entidad.Items.Where(c => c.Id == 0);
                foreach (var nuevo in nuevos)
                {
                    menu.Items.Add(nuevo);
                }

                //Eliminados
                var eliminados = menu.Items.Where(c => entidad.Items.All(d => c.Id != d.Id)).ToList();
                _menuService.EliminarItems(eliminados);

                _menuService.Guardar(menu);

                var catalogoVista = new
                {
                    menu.Id,
                    menu.Codigo,
                    menu.Nombre,
                    menu.Descripcion,
                    Items = getItems(menu.Items)
                };

                return Json(catalogoVista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = ManejadorExcepciones.HandleException(ex);
                return StatusResponseHelper.JsonErrorServidor(result.Message, true);
            }
        }

        // POST: Menu/Delete
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                _menuService.Eliminar(id);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = ManejadorExcepciones.HandleException(ex);
                return StatusResponseHelper.JsonErrorServidor(result.Message, true);
            }

        }

    }

}
