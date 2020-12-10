using System.Linq;
using System.Web.Mvc;
using Framework.Exception;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Entidades;
using Nucleo.Service;
using Negocio.Dominio.Codigos;

namespace Negocio.Api.Controllers
{
    public class AuditoriaController : BaseController
    {
        private readonly IAuditoriaRepository<Auditoria> _repository;
        private readonly IParametroService _parametroService;
        private readonly IApplication _application;

        public AuditoriaController(IHandlerExcepciones manejadorExcepciones, 
            IAuditoriaRepository<Auditoria> repository, 
            IParametroService parametroService,
            IApplication application)
            : base(manejadorExcepciones)
        {
            _repository = repository;
            _parametroService = parametroService;
            _application = application;
        }

        [HttpPost]
        public JsonResult Index(AuditoriaCriteria criteria)
        {
            var pageNumber = criteria.NumeroPagina;

            var pageSize = _parametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);

            var result = _repository.Buscar(criteria, (pageNumber - 1) * pageSize, pageSize);

            var sesionesVista = (from x in result.Data
                                 let Fecha = x.Fecha.ToString("o")
                                 orderby x.Id
                                 select new
                                 {
                                     x.Id,
                                     x.Accion,
                                     Fecha,
                                     x.Funcionalidad,
                                     x.Identificacion,
                                     x.IpAddress,
                                     x.Mensaje,
                                     x.Usuario
                                 });
            var resultado = new
            {
                Data = sesionesVista,
                TotalRegistros = result.TotalRegistros
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
