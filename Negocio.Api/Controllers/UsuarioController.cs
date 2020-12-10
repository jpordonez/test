using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Negocio.Api.Models;
using Framework.Auditoria;
using Framework.Exception;
using Framework.Logging;
using Framework.MVC;
using Framework.Util;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Seguridad;
using Nucleo.Presentacion.Constantes;
using Nucleo.Service;
using Framework.Constantes;

namespace Negocio.Api.Controllers
{
    public class UsuarioController : BaseController
    {

        private IUsuarioService _iUsuarioService;
        private IApplication _application;
        private readonly IParametroService _parametroService;
        
        private static readonly ILogAuditoria logAuditoria =
         ServiceLocator.Current.GetInstance<ILogAuditoriaFactory>().Create(FUNCIONALIDAD_GESTION_USUARIOS.Nombre);

        //Logger de la aplicacion
        private static readonly ILogger Log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(UsuarioController));


        public UsuarioController(IHandlerExcepciones manejadorExcepciones,
            IUsuarioService iUsuarioService,
            IApplication application)
            : base(manejadorExcepciones)
        {
            _iUsuarioService = iUsuarioService;
            _application = application;
        }

        // GET: DatosIniciales
        [HttpGet, ActionName("Get")]
        public JsonResult DatosIniciales()
        {
            var estadosUsuario = _iUsuarioService.GetEstadosUsuario();
            var rolesSistema = _iUsuarioService.GetRolesSistema();
            var rolesSistemaModeloVista = new List<object>();
            foreach (var rs in rolesSistema)
            {
                var rol = new
                {
                   value=rs.Id,
                   label=rs.Nombre,
                   rs.Codigo
                };
                rolesSistemaModeloVista.Add(rol);
            }
            var result = new JsonResult
            {
                Data = new
                {
                    estadosUsuario,
                    rolesSistemaModeloVista
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        [HttpPost]
        public JsonResult Index(UsuarioCriteria criteria)
        {
            var resulatdo = _iUsuarioService.GetList(criteria);
            var personasVista = (from x in resulatdo.Data
                                 let ApellidosYNombres = x.Apellidos + " " + x.Nombres
                                 let RolIds = string.IsNullOrWhiteSpace(x.RolIds) ? null : getRolIds(x.RolIds)
                                 let Clave = string.Empty
                                 orderby x.Nombres
                                 select new
                                 {
                                     x.Id,
                                     x.Nombres,
                                     x.Apellidos,
                                     x.Identificacion,
                                     Clave,
                                     x.Correo,
                                     x.Cuenta,
                                     x.Estado,
                                     x.PersonaId,
                                     x.EstadoNombre,
                                     x.RolNombres,
                                     RolIds,
                                     ApellidosYNombres
                                 });
            var resultado = new
            {
                Data = personasVista,
                resulatdo.TotalRegistros
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        private IList<int> getRolIds(string rolIds)
        {
            var idsString = rolIds.Split(',').ToList();
            var ids = idsString.Select(int.Parse).ToList();
            return ids;
        }

        [HttpPost]
        public JsonResult Create(UsuarioModeloVista usuarioViewModel)
        {
            Usuario usuario = new Usuario();
            usuario.Apellidos = usuarioViewModel.Apellidos;
            usuario.Correo = usuarioViewModel.Correo;
            var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);
            var claveEncriptada = TripleDES.Encode(usuarioViewModel.Clave, MD5.Encode(claveEncriptar));
            usuario.Clave = claveEncriptada;
            usuario.Cuenta = usuarioViewModel.Cuenta;
            usuario.Estado = usuarioViewModel.Estado;
            usuario.PersonaId = usuarioViewModel.PersonaId;
            usuario.Nombres = usuarioViewModel.Nombres;
            var rolesSistema = _iUsuarioService.GetRolesSistema();
            var rolesSeleccionados = rolesSistema.Where(rs => usuarioViewModel.RolIds.Contains(rs.Id));
            foreach (var rolSeleccionado in rolesSeleccionados)
            {
                usuario.Roles.Add(rolSeleccionado);
            }
            usuario = _iUsuarioService.Guardar(usuario);
            var usuarioVista = new
            {
                usuario.Id,
                usuario.Apellidos,
                usuario.Correo,
                usuario.Cuenta,
                usuario.Estado,
                usuario.PersonaId,
                usuario.Nombres
            };
            return Json(usuarioVista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(UsuarioModeloVista usuarioViewModel)
        {
            Usuario usuario = _iUsuarioService.Get(usuarioViewModel.Id);
            usuario.Apellidos = usuarioViewModel.Apellidos;
            usuario.Correo = usuarioViewModel.Correo;
            var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);
            var claveEncriptada = TripleDES.Encode(usuarioViewModel.Clave, MD5.Encode(claveEncriptar));
            usuario.Clave = claveEncriptada;
            usuario.Cuenta = usuarioViewModel.Cuenta;
            usuario.Estado = usuarioViewModel.Estado;
            usuario.PersonaId = usuarioViewModel.PersonaId;
            usuario.Nombres = usuarioViewModel.Nombres;
            var rolesSistema = _iUsuarioService.GetRolesSistema();
            var rolesSeleccionados = rolesSistema.Where(rs => usuarioViewModel.RolIds.Contains(rs.Id));
            usuario.Roles.Clear();
            foreach (var rolSeleccionado in rolesSeleccionados)
            {
                usuario.Roles.Add(rolSeleccionado);
            }
            usuario = _iUsuarioService.Guardar(usuario);
            var usuarioVista = new
            {
                usuario.Id,
                usuario.Apellidos,
                usuario.Correo,
                usuario.Cuenta,
                usuario.Estado,
                usuario.PersonaId,
                usuario.Nombres
            };
            return Json(usuarioVista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(UsuarioModeloVista usuarioViewModel)
        {
            _iUsuarioService.Eliminar(usuarioViewModel.Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // POST: Persona/ValidarIdentificacion
        [HttpPost]
        public JsonResult ValidarExistencia(UsuarioModeloVista entidad)
        {
            string mensaje = string.Empty;
            var existeUsuario = _iUsuarioService.ExisteUsuario(entidad.Cuenta);
            if (existeUsuario)
            {
                mensaje = "Ya existe un usuario registrado como: " + entidad.Cuenta;
                return Json(new { resultado = false, mensaje }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { resultado = true, mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}
