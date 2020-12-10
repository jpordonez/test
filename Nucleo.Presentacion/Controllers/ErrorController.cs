using System.Net;
using System.Web.Mvc;

namespace Nucleo.Presentacion.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return InternalServerError();
        }

        public ActionResult NotFound()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View("NotFound");
        }

        public ActionResult InternalServerError()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("InternalServerError");
        }

    }
}