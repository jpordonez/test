using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Framework.Cache;
using Framework.Exception;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Menus;
using Nucleo.Dominio.Seguridad;
using Framework.Util;

namespace Nucleo.Presentacion.Helpers
{
    public static class MenuExtensions
    {
        internal static void EnsureHtmlAttribute(IDictionary<string, object> attributes, string key, string value)
        {
            if (attributes == null)
            {
                attributes = new RouteValueDictionary();
            }

            if (attributes.ContainsKey(key))
            {
                attributes[key] += " " + value;
            }
            else
            {
                attributes.Add(key, value);
            }
        }


        /// <summary>
        /// Renderiza menu de acciones sobre un registro (Editar, Eliminar, Detalles)
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderMenuAction(this HtmlHelper htmlHelper,params ActionRegistro[] acciones)
        {
            return RenderMenuAction(htmlHelper, new RouteValueDictionary());
        }

        public static MvcHtmlString RenderMenuAction(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes)
        {
            return null;
        }


        public static MvcHtmlString RenderMenu(this HtmlHelper htmlHelper)
        {
            var codigoMenu = AppSettings.Get<string>("Udla.Presentacion.CodigoMenu");
            return RenderMenu(htmlHelper, codigoMenu,new RouteValueDictionary());
        }


      
        /// <summary>
        /// Contruir un panel 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderMenu(this HtmlHelper htmlHelper, string codigoMenu,IDictionary<string, object> htmlAttributes)
        {
            //TODO: Mejorar generacion de Menu
            //1. Aplicar Seguridad
            //2. Estilos
            //3. Cache o guardar Session
            //4. Menus Jerarquicos


            var app = ServiceLocator.Current.GetInstance<IApplication>();

            if (!app.IsAuthenticated())
                return null; 

            var cache = ServiceLocator.Current.GetInstance<ICacheManager>();

            int rolId = app.GetCurrentRol().Id;
            string rolCodigo = app.GetCurrentRol().Codigo;

            //TODO: JSA, como realizar reset cuando se cambia la seguridad en roles ??? 
            var codigoCache = "Udla.CarpetaLinea.Web.Cache.Menu." + codigoMenu.Trim() + "." + rolCodigo;

            var menuCache = cache.GetData(codigoCache) as MvcHtmlString;

            if (menuCache == null)
            {
                var repository = ServiceLocator.Current.GetInstance<IRepositoryNamed<Menu>>();

                ICollection<MenuItem> itemMenus = null;

                if (app.GetCurrentRol().EsAdministrador)
                {
                  //El Rol Administrador tiene todos los items de menu
                   var menu = repository.Get(codigoMenu, include => include.Items);
                   if (menu != null)
                       itemMenus = menu.Items;
                }
                else { 
               
                    itemMenus = (from r in repository.GetQuery<Rol>().Where(r => r.Id == rolId)
                                     from p in r.Permisos
                                     join a in repository.GetQuery<Accion>()
                                     on p.AccionId equals a.Id
                                     join f in repository.GetQuery<Funcionalidad>()
                                     on a.FuncionalidadId equals f.Id
                                     join m in repository.GetQuery<MenuItem>()
                                     on f.Id equals m.FuncionalidadId
                                     join mnu in repository.GetQuery()
                                     on m.MenuId equals mnu.Id
                                     where mnu.Codigo == codigoMenu
                                     select m
                            ).Distinct().
                            Union(
                                from m in repository.GetQuery<MenuItem>()
                                join mnu in repository.GetQuery<Menu>()
                                on m.MenuId equals mnu.Id
                                where  m.FuncionalidadId == null
                                && mnu.Codigo == codigoMenu
                                select m
                            ).ToList();

                }

                if (itemMenus == null)
                {
                    string error = string.Format("No existe le menún [{0}]", codigoMenu);
                    throw new GenericException(error, error);
                }

                menuCache = BuildMenu(itemMenus, htmlAttributes);

                cache.Add(codigoCache, menuCache);
            }


            return menuCache;

        }

        private static MvcHtmlString BuildMenu(ICollection<MenuItem> itemMenus, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tagBuilder = new TagBuilder("ul");

            EnsureHtmlAttribute(htmlAttributes, "class", "nav navbar-nav");

            tagBuilder.MergeAttributes(htmlAttributes);

            foreach (var item in itemMenus.OrderBy(a => a.Orden))
            {
                if (item.EstadoId == EstadoItemMenu.Desactivo)
                    continue;

                if (item.PadreCodigo == null)
                {
                    //Obtener todos los hijos
                    var hijos = itemMenus.Where(mnuItem => mnuItem.PadreCodigo == item.Codigo).OrderBy(mnuItem => mnuItem.Orden).ToList();

                    if (hijos.Count == 0)
                    {
                        //Crear unicamente si el item no es un contenedor, ya que un contenedor si no tiene hijos no debe crearse
                        if (item.TipoId != TipoItemMenu.Contenedor)
                            tagBuilder.InnerHtml += GenerateMenuItem(item);
                    }
                    else
                    {
                        TagBuilder li = new TagBuilder("li");
                        li.AddCssClass("dropdown");

                        var url = "#";

                        TagBuilder a = new TagBuilder("a");
                        a.AddCssClass("dropdown-toggle");
                        a.Attributes.Add("data-toggle", "dropdown");
                        a.MergeAttribute("href", url);
                        a.InnerHtml += item.Nombre;

                        li.InnerHtml += a;

                        TagBuilder ul = new TagBuilder("ul");
                        ul.AddCssClass("dropdown-menu");
                        ul.Attributes.Add("role", "menu");

                        foreach (var hijo in hijos)
                        {
                            if (hijo.EstadoId == EstadoItemMenu.Desactivo)
                                continue;

                            ul.InnerHtml += GenerateMenuItem(hijo);

                        }

                        li.InnerHtml += ul;
                        tagBuilder.InnerHtml += li;

                    }
                }
            }

            return  MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        
        }

        private static string GenerateMenuItem(MenuItem item) {
            TagBuilder li = new TagBuilder("li");


            //TODO:JSA, REVISAR EL TEMA DE MENUS, LA URL. QUE PASA SI EL SITIO ESTA COMO APLICACION.
            var url = VirtualPathUtility.ToAbsolute("~/" + item.Url);

            TagBuilder a = new TagBuilder("a");
            a.MergeAttribute("href", url);
            a.InnerHtml += item.Nombre;

            li.InnerHtml += a;

            return li.ToString();
        }
    }
}