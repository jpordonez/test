using System.Web.Mvc;
using Framework.Cache;
using Framework.Exception;
using Framework.MVC;
using Framework.Repository;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Presentacion.Controllers
{ 
    public class PermisosController : BaseController  
    {
        private IApplication _repository;
        private IHandlerExcepciones _manejadorExcepciones;
        private IRepository<Accion> _repositoryAccion;
        private IRepository<Funcionalidad> _repositoryFuncionalidad;



        public PermisosController(IHandlerExcepciones manejadorExcepciones, IRepository<Accion> repositoryAccion, IRepository<Funcionalidad> repositoryFuncionalidad, IApplication repository, ICacheManager cache)
            : base(manejadorExcepciones)
        {

            _manejadorExcepciones = manejadorExcepciones;
            _repository = repository;
            _repositoryAccion = repositoryAccion;
            _repositoryFuncionalidad = repositoryFuncionalidad;


        }
        // GET: Permisos
        public ActionResult Index()
        {
            ViewBag.FuncionalidadId = new SelectList(_repositoryFuncionalidad.GetList(), "Id", "Nombre");
            return View();
        }


    }
}
