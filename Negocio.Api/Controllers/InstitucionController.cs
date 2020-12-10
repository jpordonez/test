using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Negocio.Dominio;
using Negocio.Dominio.Criteria;
using Nucleo.Service;
using Nucleo.Dominio.Models;
using Nucleo.Dominio.Criteria;
using Negocio.Dominio.Constantes;

namespace Negocio.Api.Controllers
{
    public class InstitucionController : Controller
    {

        private ICatalogoService _iCatalogoService;
        private IInstitucionService _iInstitucionService;

        public InstitucionController(ICatalogoService iCatalogoService,
                                IInstitucionService iInstitucionService)
        {
            _iCatalogoService = iCatalogoService;
            _iInstitucionService = iInstitucionService;
        }

        // GET: DatosIniciales
        [HttpGet, ActionName("Get")]
        public JsonResult DatosIniciales()
        {
            var inscritosEn = _iCatalogoService.GetItemsCatalogo(ConstantesCatalogos.INSCRITOS_EN);
            List<object> inse = new List<object>();
            foreach (var ine in inscritosEn)
            {
                var inscritoEn = new
                {
                    value = ine.Id,
                    label = ine.Nombre
                };
                inse.Add(inscritoEn);
            }            
            var result = new JsonResult
            {
                Data = new
                {
                    inse                    
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }
        // POST: Institucion
        [HttpPost]
        public JsonResult Index(InstitucionCriteria criteria)
        {
            var resulatdo = _iInstitucionService.GetList(criteria);
            var institucionVista = (from x in resulatdo.Data
                                    orderby x.RazonSocial
                                    let NumeroAcuerdoRegistro = x.NumeroAcuerdo
                                    let RepresentanteNombresCompletos = x.RepresentanteNombres+" "+x.RepresentanteApellidos
                                    select new
                                    {
                                        x.Id,
                                        x.IncritoEnNombre,
                                        x.InscritoId,
                                        x.LugarInscripcion,
                                        NumeroAcuerdoRegistro,
                                        x.RazonSocial,
                                        x.RepresentanteApellidos,
                                        x.RepresentanteId,
                                        x.RepresentanteNombres,
                                        RepresentanteNombresCompletos,
                                        x.RepresentanteIdentificacion,
                                        x.Ruc
                                    });
            var resultado = new
            {
                Data = institucionVista,
                resulatdo.TotalRegistros
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // POST: Institucion/Details
        [HttpPost]
        public JsonResult Details(Institucion institucion)
        {
            institucion = _iInstitucionService.Get(institucion.Id);
            var institucionVista = new
            {
                institucion.Id,
                //institucion.IncritoEnNombre,
                institucion.InscritoId,
                institucion.LugarInscripcion,
                institucion.NumeroAcuerdoRegistro,
                institucion.RazonSocial,
                //institucion.RepresentanteApellidos,
                institucion.PersonaId,
                //institucion.RepresentanteNombres,
                institucion.Ruc
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Institucion/Create
        [HttpPost]
        public JsonResult Create(Institucion institucion)
        {
            institucion = _iInstitucionService.Guardar(institucion);
            var institucionVista = new
            {
                institucion.Id,
                //institucion.IncritoEnNombre,
                institucion.InscritoId,
                institucion.LugarInscripcion,
                institucion.NumeroAcuerdoRegistro,
                institucion.RazonSocial,
                //institucion.RepresentanteApellidos,
                institucion.PersonaId,
                //institucion.RepresentanteNombres,
                institucion.Ruc
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Institucion/Edit
        [HttpPost]
        public JsonResult Edit(Institucion institucionViewModel)
        {
            Institucion institucion = _iInstitucionService.Get(institucionViewModel.Id);
            institucion.InscritoId = institucionViewModel.InscritoId;
            institucion.LugarInscripcion = institucionViewModel.LugarInscripcion;
            institucion.NumeroAcuerdoRegistro = institucionViewModel.NumeroAcuerdoRegistro;
            institucion.RazonSocial = institucionViewModel.RazonSocial;
            institucion.PersonaId = institucionViewModel.PersonaId;
            institucion.Ruc = institucionViewModel.Ruc;
            institucion = _iInstitucionService.Guardar(institucion);
            var institucionVista = new
            {
                institucion.Id,
                //institucion.IncritoEnNombre,
                institucion.InscritoId,
                institucion.LugarInscripcion,
                institucion.NumeroAcuerdoRegistro,
                institucion.RazonSocial,
                //institucion.RepresentanteApellidos,
                institucion.PersonaId,
                //institucion.RepresentanteNombres,
                institucion.Ruc
            };
            return Json(institucionVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Institucion/Delete/5
        [HttpPost]
        public JsonResult Delete(Institucion institucion)
        {
            _iInstitucionService.Eliminar(institucion.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
