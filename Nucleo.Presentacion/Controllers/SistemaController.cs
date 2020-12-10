using System;
using System.Web.Mvc;
using Framework.Cache;
using Framework.Exception;
using Framework.MVC;
using Nucleo.Dominio;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Nucleo.Dominio.Entidades;
using Negocio.Dominio.Models;
using System.Reflection;
using Framework;

namespace Nucleo.Presentacion.Controllers
{
    public class SistemaController : BaseController
    {
        private readonly IApplication _application;
        private readonly ICacheManager _cacheManager;
        private readonly DbContext _context;


        public SistemaController(IHandlerExcepciones manejadorExcepciones,
                                    IApplication application,
                                    ICacheManager cacheManager,
                                    DbContext context)
            : base(manejadorExcepciones)
        {

            _application = application;
            _cacheManager = cacheManager;
            _context = context;
        }


        // GET: Sistema
        public ActionResult Index()
        {
            ViewBag.NombreUsuario = _application.GetCurrentUser().Nombres + " " +
            _application.GetCurrentUser().Apellidos;
            return View();
        }

        public ActionResult LimpiarCache()
        {
            try
            {
                _cacheManager.Flush();
            }
            catch (Exception ex)
            {
                return this.ExceptionResult(ManejadorExcepciones.HandleException(ex));
            }

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public ActionResult RecargarContextoEF()
        {
            try
            {
                Type tipoNucleo = typeof(Catalogo);
                Type tipoNegocio = typeof(ComponenteEducativo);
                var tiposNucleo = Assembly.GetAssembly(tipoNucleo).GetTypes().Where(t=>t.GetInterfaces().Contains(typeof(IEntity)));
                var tiposNegocio = Assembly.GetAssembly(tipoNegocio).GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IEntity)));
                foreach (var tipo in tiposNucleo)
                {
                    ((IObjectContextAdapter)_context).ObjectContext.Refresh(RefreshMode.ClientWins, _context.Set(tipo));
                }
                foreach (var tipo in tiposNegocio)
                {
                    ((IObjectContextAdapter)_context).ObjectContext.Refresh(RefreshMode.ClientWins, _context.Set(tipo));
                }
            }
            catch (Exception ex)
            {
                return this.ExceptionResult(ManejadorExcepciones.HandleException(ex));
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}