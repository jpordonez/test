using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Framework.Cache;
using Framework.Exception;
using Framework.MVC;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Menus;
using Nucleo.Dominio.Seguridad;
using Nucleo.Presentacion.Helpers;
using Nucleo.Service;
using Framework.Constantes;
using Framework.Util;

namespace Nucleo.Presentacion.Controllers
{
    public class InicioController : BaseController
    {
        private readonly IApplication _application;
        private readonly IParametroService _parametroService;
        private IRepository<ParametroSistema> _parametroSistema;

        public InicioController(IHandlerExcepciones manejadorExcepciones, IApplication application, IParametroService parametroService, IRepository<ParametroSistema> parametrosistema)
            : base(manejadorExcepciones)
        {
            _application = application;
            _parametroService = parametroService;
            _parametroSistema = parametrosistema;
        }

        // GET: Inicio
        public ActionResult Index(string Texto, TipoMensaje? Tipo)
        {

            Usuario usuario = _application.GetCurrentUser();
            Rol rol = _application.GetCurrentRol();

            ViewBag.NOMBRE_USUARIO = usuario.Nombres + " " + usuario.Apellidos;

            ViewBag.ROL_USUARIO = rol.Nombre;

            ViewBag.Texto = Texto;
            ViewBag.Tipo = Tipo;

            return View();
        }

        [AllowAnonymous, ChildActionOnly]
        public PartialViewResult Hora()
        {
            TimeSpan hora = _application.getDateTime().TimeOfDay;
            return PartialView("_Hora", hora);
        }

        [HttpPost]
        public JsonResult Menu()
        {
            var codigoMenu = AppSettings.Get<string>(ConstantesWebConfig.CODIGO_MENU);
            if (codigoMenu == null)
            {
                throw new Exception("No existe la clave en WebConfig: " + ConstantesWebConfig.CODIGO_MENU);
            }
            var app = ServiceLocator.Current.GetInstance<IApplication>();

            if (!app.IsAuthenticated())
                return null;

            var cache = ServiceLocator.Current.GetInstance<ICacheManager>();

            int rolId = app.GetCurrentRol().Id;
            string rolCodigo = app.GetCurrentRol().Codigo;

            //TODO: JSA, como realizar reset cuando se cambia la seguridad en roles ??? 
            var codigoCache = "Web.Cache.Menu." + codigoMenu.Trim() + "." + rolCodigo;

            var menuCache = cache.GetData(codigoCache);

            if (menuCache == null)
            {
                var repository = ServiceLocator.Current.GetInstance<IRepositoryNamed<Menu>>();

                ICollection<MenuItem> itemMenus = null;

                if (app.GetCurrentRol().EsAdministrador)
                {
                    //El Rol Administrador tiene todos los items de menu
                    var menu = repository.Get(codigoMenu, include => include.Items);
                    if (menu != null)
                    {
                        itemMenus = menu.Items;
                    }
                }
                else
                {
                    itemMenus = (from p in repository.GetQuery<Permiso>().Where(p => p.RolId == rolId)
                                 join a in repository.GetQuery<Accion>()
                                 on p.AccionId equals a.Id
                                 join f in repository.GetQuery<Funcionalidad>()
                                 on a.FuncionalidadId equals f.Id
                                 join m in repository.GetQuery<MenuItem>()
                                 on f.Id equals m.FuncionalidadId
                                 join mnu in repository.GetQuery()
                                 on m.MenuId equals mnu.Id
                                 where mnu.Codigo == codigoMenu
                                 && !p.NoVisualizarEnMenu
                                 select m
                            ).Distinct().ToList();
                }

                if (itemMenus == null)
                {
                    string error = string.Format("No existe el menún [{0}]", codigoMenu);
                    throw new GenericException(error, error);
                }

                var todosLositems = repository.GetQuery<MenuItem>().ToList();

                var contenedores = (from m in todosLositems
                                    where itemMenus.Select(im => im.PadreCodigo).Contains(m.Codigo)
                                    select m).ToList();

                var menusPadres = (from x in contenedores
                                   let label = x.Nombre
                                   let icon = x.Icono
                                   //let command = x.Url
                                   let url = x.Url.Equals("#") ? null : x.Url
                                   let routerLink = x.Url.Equals("#") ? null : x.Url
                                   let items = MenusHios(itemMenus, x)
                                   let expanded = true
                                   let disabled = false
                                   where x.PadreCodigo == null
                                   && items != null && items.Any()
                                   orderby x.Orden
                                   select new { label, icon, /*command,*/ url, routerLink, items, expanded, disabled });


                //?: MenuItem[];

                menuCache = menusPadres;

                cache.Add(codigoCache, menuCache);
            }

            var result = new JsonResult
            {
                Data = menuCache,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        public IEnumerable<object> MenusHios(ICollection<MenuItem> itemMenus, MenuItem menuItem)
        {
            var menusHijos = (from x in itemMenus
                              let label = x.Nombre
                              let icon = x.Icono
                              //let command = x.Url
                              let url = x.Url.Equals("#") ? null : x.Url
                              let routerLink = x.Url.Equals("#") ? null : x.Url
                              let expanded = true
                              let disabled = false
                              where x.PadreCodigo == menuItem.Codigo
                              orderby x.Orden
                              select new { label, icon, /*command,*/ url, routerLink, expanded, disabled });
            return menusHijos;
        }

    }
}