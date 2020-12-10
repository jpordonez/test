using Negocio.Api.Models;
using Framework.Exception;
using Nucleo.Dominio;
using Nucleo.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Criteria;
using Negocio.Dominio.Constantes;

namespace Negocio.Api.Controllers
{

    public class PersonaController : Controller
    {

        private ICatalogoService _iCatalogoService;
        private IPersonaService _iPersonaService;
        private IApplication _iApplication;

        public PersonaController(ICatalogoService iCatalogoService,
                                IPersonaService iPersonaService,
                                IApplication iApplication)
        {
            _iCatalogoService = iCatalogoService;
            _iPersonaService = iPersonaService;
            _iApplication = iApplication;
        }

        // GET: DatosIniciales
        [HttpGet, ActionName("Get")]
        [AllowAnonymous]
        public JsonResult DatosIniciales()
        {
            var tiposIdentificacion = _iCatalogoService.GetItemsCatalogo(ConstantesCatalogos.CAT_TIPO_IDENTIFICACION);
            List<object> tpsi = new List<object>();
            foreach (var tpi in tiposIdentificacion)
            {
                var tipoIdentificacion = new
                {
                    value = tpi.Id,
                    label = tpi.Nombre
                };
                tpsi.Add(tipoIdentificacion);
            }
            var estadosCivil = _iCatalogoService.GetItemsCatalogo(ConstantesCatalogos.CAT_ESTADO_CIVIL);
            List<object> etsc = new List<object>();
            foreach (var etc in estadosCivil)
            {
                var estadoCivil = new
                {
                    value = etc.Id,
                    label = etc.Nombre
                };
                etsc.Add(estadoCivil);
            }
            var result = new JsonResult
            {
                Data = new
                {
                    tpsi,
                    etsc
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        // POST: Personas
        [HttpPost]
        public JsonResult Index(PersonaCriteria personaCriteria)
        {
            var resulatdo = _iPersonaService.GetList(personaCriteria);
            var personasVista = (from x in resulatdo.Data
                                 let tipoDocumentoNombre = getTipoIdentificacion(x.TipoDocumento)
                                 //let estadoCivilNombre = getEstadoCivil(x.EstadoCivil)
                                 let ApellidosYNombres = x.Apellidos + " " + x.Nombres
                                 orderby x.Nombres
                                 select new
                                 {
                                     x.Id,
                                     x.Nombres,
                                     x.Apellidos,
                                     x.PrimerNombre,
                                     x.SegundoNombre,
                                     x.PrimerApellido,
                                     x.SegundoApellido,
                                     x.Identificacion,
                                     x.Movil,
                                     x.Telefono,
                                     x.Correo,
                                     x.TipoDocumento,
                                     x.EstadoCivil,
                                     tipoDocumentoNombre,
                                     //estadoCivilNombre,
                                     ApellidosYNombres
                                 });
            var resultado = new
            {
                Data = personasVista,
                resulatdo.TotalRegistros
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private string getTipoIdentificacion(int tipoDocumentoId)
        {
            var tiposIdentificacion = _iCatalogoService.GetItemsCatalogo(ConstantesCatalogos.CAT_TIPO_IDENTIFICACION);
            var tipoDocumentoNombre = tiposIdentificacion.FirstOrDefault(td => td.Id == tipoDocumentoId);
            return tipoDocumentoNombre.Nombre;
        }

        private string getEstadoCivil(int? estadoCivilId)
        {
            if (estadoCivilId == null)
            {
                return string.Empty;
            }
            var estadosCivil = _iCatalogoService.GetItemsCatalogo(ConstantesCatalogos.CAT_ESTADO_CIVIL);
            var estadoCivilNombre = estadosCivil.FirstOrDefault(td => td.Id == estadoCivilId);
            return estadoCivilNombre.Nombre;
        }

        // GET: Persona/Details/5
        public JsonResult Details(Persona persona)
        {
            if (persona.Id == 0)
            {
                persona.Id = _iApplication.GetCurrentUser().Id;
            }

            persona = _iPersonaService.Get(persona.Id);
            var personaVista = new
            {
                persona.Id,
                persona.PrimerNombre,
                persona.SegundoNombre,
                persona.PrimerApellido,
                persona.SegundoApellido,
                persona.Identificacion,
                persona.Correo,
                persona.Movil,
                persona.Telefono,
                persona.EstadoCivil,
                persona.TipoDocumento
            };
            return Json(personaVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Persona/Create
        [HttpPost]
        public JsonResult Create(PersonaViewModel personaViewModel)
        {
            string mensaje = string.Empty;

            var esValidaIdentificacion = _iPersonaService.ValidarIdentificacion(null, personaViewModel.TipoDocumento, personaViewModel.Identificacion, out mensaje);
            if (!esValidaIdentificacion)
            {
                throw new NegocioExcepcion(mensaje);
            }

            Persona persona = new Persona();
            persona.PrimerNombre = personaViewModel.PrimerNombre;
            persona.SegundoNombre = personaViewModel.SegundoNombre;
            persona.PrimerApellido = personaViewModel.PrimerApellido;
            persona.SegundoApellido = personaViewModel.SegundoApellido;
            persona.Identificacion = personaViewModel.Identificacion;
            persona.Correo = personaViewModel.Correo;
            persona.Movil = personaViewModel.Movil;
            persona.Telefono = personaViewModel.Telefono;
            persona.EstadoCivil = personaViewModel.EstadoCivil;
            persona.TipoDocumento = personaViewModel.TipoDocumento;
            persona = _iPersonaService.Guardar(persona);
            var personaVista = new
            {
                persona.Id,
                persona.PrimerNombre,
                persona.SegundoNombre,
                persona.PrimerApellido,
                persona.SegundoApellido,
                persona.Identificacion,
                persona.Correo,
                persona.Movil,
                persona.Telefono,
                persona.EstadoCivil,
                persona.TipoDocumento
            };
            return Json(personaVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public JsonResult Edit(PersonaViewModel entidad)
        {
            string mensaje = string.Empty;

            var identificacion = entidad.Identificacion;
            //Creacion de Persona
            var p = _iPersonaService.Get(identificacion);
            var existeIdentificacion = p != null && entidad.Id != p.Id;
            if (existeIdentificacion)
            {
                mensaje = "Ya existe una persona registrada con la identificación: " + identificacion;
                throw new NegocioExcepcion(mensaje);
            }

            var esValidaIdentificacion = _iPersonaService.ValidarIdentificacion(entidad.Id, entidad.TipoDocumento, entidad.Identificacion, out mensaje);
            if (!esValidaIdentificacion)
            {
                throw new NegocioExcepcion(mensaje);
            }

            Persona persona = _iPersonaService.Get(entidad.Id);
            persona.PrimerNombre = entidad.PrimerNombre;
            persona.SegundoNombre = entidad.SegundoNombre;
            persona.PrimerApellido = entidad.PrimerApellido;
            persona.SegundoApellido = entidad.SegundoApellido;
            persona.Identificacion = entidad.Identificacion;
            persona.Correo = entidad.Correo;
            persona.Movil = entidad.Movil;
            persona.Telefono = entidad.Telefono;
            persona.EstadoCivil = entidad.EstadoCivil;
            persona.TipoDocumento = entidad.TipoDocumento;

            persona = _iPersonaService.Guardar(persona);
            var personaVista = new
            {
                persona.Id,
                persona.PrimerNombre,
                persona.SegundoNombre,
                persona.PrimerApellido,
                persona.SegundoApellido,
                persona.Identificacion,
                persona.Correo,
                persona.Movil,
                persona.Telefono,
                persona.EstadoCivil,
                persona.TipoDocumento
            };
            return Json(personaVista, JsonRequestBehavior.AllowGet);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public JsonResult Delete(Persona persona)
        {
            _iPersonaService.Eliminar(persona.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Persona/ValidarIdentificacion
        [HttpPost]
        public JsonResult ValidarIdentificacionYExistencia(PersonaViewModel entidad)
        {
            string mensaje = string.Empty;

            var esValidaIdentificacion = _iPersonaService.ValidarIdentificacion(entidad.PersonaId, entidad.TipoDocumento, entidad.Identificacion, out mensaje);
            if (!esValidaIdentificacion)
            {
                return Json(new { resultado = false, mensaje }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { resultado = true, mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Persona/ValidarExistenciaCorreo
        [HttpPost]
        public JsonResult ValidarExistenciaCorreo(PersonaViewModel entidad)
        {
            string mensaje = string.Empty;
            var esValidoCorreo = _iPersonaService.ValidarExistenciaCorreo(entidad.PersonaId, entidad.Correo);
            if (!esValidoCorreo)
            {
                mensaje = "Ya existe una persona registrada con el correo ingresado.";
                return Json(new { resultado = false, mensaje }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { resultado = true, mensaje }, JsonRequestBehavior.AllowGet);
            }
        }

    }

}
