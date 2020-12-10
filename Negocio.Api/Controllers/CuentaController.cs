using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Nucleo.Dominio;
using Nucleo.Service;
using Nucleo.Dominio.Seguridad;
using Framework.Auditoria;
using Framework.Logging;
using Nucleo.Presentacion.Constantes;
using Framework.MVC;
using Framework.Security;
using Framework.Exception;
using Nucleo.Presentacion.Models;
using Nucleo.Presentacion.Helpers;
using Framework.Util;
using Framework.Repository;
using Nucleo.Dominio.DTO;
using Negocio.Service;
using System.IO;
using Framework.Constantes;
using System.Collections.Generic;
using Nucleo.Dominio.Entidades;
using Negocio.Dominio.Constantes;

namespace Negocio.Api.Controllers
{
    [AllowAnonymous]
    public class CuentaController : BaseController
    {

        private readonly IUsuarioRepository<Usuario> _repository;
        private readonly IRepository<Persona> _repositoryPersona;
        private readonly IRolService _rolService;

        private static readonly ILogAuditoria logAuditoria =
            ServiceLocator.Current.GetInstance<ILogAuditoriaFactory>().Create(FUNCIONALIDAD_GESTION_USUARIOS.Nombre);

        //Logger de la aplicacion
        private static readonly ILogger Log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(CuentaController));


        /// <summary>
        /// 
        /// </summary>
        private IAccessService _accessService;


        private IApplication _application;

        private IExternalInfoUserProvider _externalInfoUserProvider;

        IParametroService _parametroService;

        public CuentaController(IHandlerExcepciones manejadorExcepciones,
            IUsuarioRepository<Usuario> repository, IAccessService accessService,
            IApplication application, IRolService rolService,
            IExternalInfoUserProvider externalInfoUserProvider,
            IParametroService parametroService,
            IRepository<Persona> repositoryPersona) :
            base(manejadorExcepciones)
        {
            _repository = repository;

            _accessService = accessService;

            _application = application;

            _rolService = rolService;

            _externalInfoUserProvider = externalInfoUserProvider;

            _parametroService = parametroService;

            _repositoryPersona = repositoryPersona;

        }

        //Visualizar login elmah
        public ActionResult LogOn()
        {
            return View();
        }

        //Ingresar elmah
        [HttpPost]
        public ActionResult LogOn(string cuenta, string clave)
        {
            var usuario = _repository.Get(cuenta);
            var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);
            var claveEncriptada = TripleDES.Encode(clave, MD5.Encode(claveEncriptar));
            if (usuario != null && usuario.Clave.Equals(claveEncriptada) && usuario.Roles.Any(r => r.EsAdministrador))
            {
                FormsAuthentication.SetAuthCookie(cuenta, false);
                return Redirect("~/elmah.axd");
            }
            else
            {
                ModelState.AddModelError("", "Usted no esta autorizado para realizar esta acción.");
            }
            return View();
        }

        // GET: Defecto
        public JsonResult Ingreso()
        {
            return Json("Servicio Habilitado", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Ingresar(LoginViewModel model)
        {

            if (model.Usuario != null && !model.Usuario.IsEmpty() && model.Password != null && !model.Password.IsEmpty())
            {
                //1. Autentificacion contra Membership
                var proveedorMembresia = Membership.Provider;

                model.Usuario = model.Usuario.Trim();
                MembershipUser user = Membership.GetUser(model.Usuario);

                if (user == null)
                {
                    Log.DebugFormat("No existe el usuario [{0}]", model.Usuario);
                    var error = "Usuario ó Clave incorrecta";
                    var result = StatusResponseHelper.JsonNoAutenticado(error, true);
                    return result;
                }


                if (!user.IsApproved)
                {
                    var error = string.Format("El usuario [{0}], se encuentra pendiente de activación, revice su correo o contáctese con soporte.", model.Usuario);
                    var result = StatusResponseHelper.JsonNoAutenticado(error, true);
                    return result;
                }

                //1.1. Usuario Bloqueado
                //if (user.IsLockedOut)
                //{
                //    var mensaje =
                //           string.Format("El usuario " + model.Usuario + ", se encuentra bloqueado");
                //    logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);


                //    ModelState.AddModelError("", string.Format("El usuario [{0}], se encuentra bloqueado", model.Usuario));
                //    return IntentarIngreso(model);
                //}

                //TODO: Personalizar mensajes de AD
                //try
                //{

                //    var server = ConfigurationManager.AppSettings["Udla.CarpetaLinea.Url.ActiveDirectory"];
                //    var entry = new DirectoryEntry(server, model.Usuario, model.Password);
                //    var nativeObject = entry.NativeObject;
                //}
                //catch (DirectoryServicesCOMException cex)
                //{
                //    //TODO: Capturar por codigos de excepciones.
                //    if (cex.ExtendedErrorMessage.Contains("532"))
                //    {
                //        var mensaje =
                //          string.Format("La contraseña del usuario " + model.Usuario + ", se encuentra expirada");
                //        logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);

                //        ModelState.AddModelError("", string.Format("La contraseña del usuario [{0}] está expirada. Por favor utilice la opción 'Cambiar contraseña'", model.Usuario));
                //        ViewBag.ShowLink = false;
                //        return IntentarIngreso(model);
                //    }
                //    else if (cex.ExtendedErrorMessage.Contains("773"))
                //    {
                //        var mensaje =
                //          string.Format("El usuario " + model.Usuario + ", debe cambiar la contraseña");
                //        logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);

                //        ModelState.AddModelError("", string.Format("El usuario [{0}] debe cambiar la contraseña", model.Usuario));
                //        return IntentarIngreso(model);
                //    }
                //    else if (cex.ExtendedErrorMessage.Contains("775"))
                //    {
                //        //TODO JLA: Personalizar mensaje contra tiempo de duracion de bloqueo
                //        var minutes = getLockoutDuration(model.Usuario);
                //        var mensaje =
                //          string.Format("El usuario " + model.Usuario + ", se encuentra bloqueado");

                //        logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);

                //        ModelState.AddModelError("", string.Format("El usuario [{0}] se encuentra bloqueado. Por favor intentarlo en [{1}] minutos", model.Usuario, minutes));
                //        return IntentarIngreso(model);
                //    }
                //}

                var membresia = proveedorMembresia.ValidateUser(model.Usuario, model.Password);
                if (membresia)
                {

                    Usuario usuario = _repository.Get(model.Usuario);
                    if (usuario.PersonaId.HasValue)
                    {
                        var persona = _repositoryPersona.Get((int)usuario.PersonaId);
                        usuario.Nombres = persona.PrimerNombre + " " + persona.SegundoNombre;
                        usuario.Apellidos = persona.PrimerApellido + " " + persona.SegundoApellido;
                        usuario.Identificacion = persona.Identificacion;
                        usuario.Correo = persona.Correo;
                    }
                    else
                    {
                        usuario.Nombres = "Anonimo";
                        usuario.Apellidos = string.Empty;
                        usuario.Identificacion = string.Empty;
                        usuario.Correo = string.Empty;
                    }

                    if (usuario == null)
                    {
                        //var sincronizar_usuario_externo = _parametroService.GetValor<bool>(CodigosParametros.PARAMETRO_SEGURIDAD_SINCRONIZAR_USUARIOS_EXTERNOS);

                        //if (sincronizar_usuario_externo)
                        //{
                        //    usuario = SincronizarUsuarioExterno(model.Usuario, infoExternal, rolesInternosExternos);
                        //}
                        //else
                        //{

                        var error = string.Format("No existe el usuario [{0}]", model.Usuario);
                        var result = StatusResponseHelper.JsonNoAutenticado(error, false);
                        return result;
                        //}
                    }

                    var modelRol = new SeleccionarRolViewModel();
                    modelRol.UsuarioId = usuario.Id;
                    modelRol.NombreUsuario = usuario.ToString();
                    modelRol.IPClient = model.IPClient;

                    //Unir Roles asociados al usuario
                    var _rolesUsuario = usuario.Roles;
                    foreach (var item in _rolesUsuario)
                    {
                        var rolView = new RolViewModel() { CodigoRol = item.Codigo, NombreRol = item.Nombre };
                        modelRol.Roles.Add(rolView);
                    }


                    if (modelRol.Roles.Count == 1)
                    {
                        var mensaje =
                        string.Format("El usuario {0}, ingresa por defecto con el codigo de rol {1}", usuario, modelRol.Roles.FirstOrDefault().NombreRol);

                        //Registro Auditoria - Hora de inicio de sesión en el sistema.
                        logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);
                        //Si unicamente existe un rol autentificar
                        return AutentificarUsuario(usuario, null, modelRol.Roles.FirstOrDefault().CodigoRol);

                    }
                    else if (modelRol.Roles.Count > 1)
                    {
                        modelRol.Roles = modelRol.Roles.OrderBy(c => c.NombreRol).ToList();
                        var usuarioView = new
                        {
                            usuId = usuario.Id,
                            version = usuario.VersionRegistro,
                            usuNombres = usuario.Nombres,
                            usuApellidos = usuario.Apellidos,
                            usuIdentificacion = usuario.PersonaId,
                            usuDireccion = "",
                            usuUsuario = usuario.Cuenta,
                            usuClave = "",
                            usuCorreo = usuario.Correo,
                            usuEstado = usuario.Estado
                        };

                        var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);
                        var minutosExpiracionToken = Convert.ToInt32(AppSettings.Get<string>(ConstantesWebConfig.TOKEN_TIEMPOSESION));
                        //Se fija -1 al rol y sesion actual mientras el usuario elije un rol
                        var token = Token.GenerateToken(Base64.Encode(claveEncriptar), usuario.Id, -1, -1, minutosExpiracionToken);

                        var roles = (from x in modelRol.Roles
                                     let label = x.NombreRol
                                     let value = x.CodigoRol
                                     orderby x.NombreRol
                                     select new { label, value });

                        var result = new JsonResult
                        {
                            Data = new
                            {
                                roles,
                                usuario = usuarioView,
                                miToken = token,
                                autenticado = true
                            },
                            //ContentType = contentType,
                            //ContentEncoding = contentEncoding,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                        return result;
                    }
                    else if (modelRol.Roles.Count == 0)
                    {
                        string error = string.Format("Usuario {0}, no posee roles establecidos para ingresar al sistema", model.Usuario);
                        var mensaje =
                        string.Format("El usuario {0}, no posee roles establecidos para ingresar al sistema", usuario);

                        //Registro Auditoria - Hora de inicio de sesión en el sistema.
                        logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);
                        var result = StatusResponseHelper.JsonNoAutenticado(error, true);
                        return result;
                    }
                }
                else
                {

                    var mensaje =
                        string.Format("El usuario {0}, ha intentado realizar Loguin en el sistema, usuario no autenticado", model.Usuario);
                    //Registro Auditoria - Hora de intento de logueo en la aplicación.
                    logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);

                    var result = StatusResponseHelper.JsonNoAutenticado("Usuario o contraseña incorrecto", true);
                    return result;
                }
            }

            var result1 = StatusResponseHelper.JsonNoAutenticado("Usuario o contraseña incorrecto", true);
            return result1;

        }


        //private ActionResult IntentarIngreso(IngresoViewModel model)
        //{
        //    var recordarcontrasena = _parametroService.GetValor<string>(CodigosParametros.PARAMETRO_RECUPERA_CONTRA);
        //    ViewBag.RECUERDACONTRA = recordarcontrasena;


        //    bool aplicarMecanismo = false;
        //    bool.TryParse(ConfigurationManager.AppSettings["Udla.Seguridad.DireccionIP.AplicarMecanismoJavascript"], out aplicarMecanismo);

        //    ViewBag.AplicarMecanismoJavascriptObtenerIPCliente = aplicarMecanismo;
        //    ViewBag.SitioObtenerIPCliente = ConfigurationManager.AppSettings["Udla.Seguridad.DireccionIP.SitioObtenerIPCliente"];

        //    return View("Ingreso", model);
        //}



        [HttpPost]
        public JsonResult SeleccionarRol(SeleccionarRolViewModel seleccionarRolViewModel)
        {
            var tokenHeader = seleccionarRolViewModel.Token;
            var claveEncriptar = Base64.Encode(AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION));
            var tokenResult = Token.DecodeToken(claveEncriptar, tokenHeader);
            if (!tokenResult.Validated)
            {
                var mensaje = string.Empty;
                if (tokenResult.Errors[0].Equals(TokenValidationStatus.Expired))
                {
                    mensaje = string.Format("Su sesion ha expirado.");
                }
                else
                {
                    if (tokenResult.Errors[0].Equals(TokenValidationStatus.WrongToken))
                    {
                        mensaje = string.Format("El valor de token es invalido.");
                    }
                }

                var result = StatusResponseHelper.JsonNoAutenticado(mensaje, false);
                return result;
            }


            if (tokenResult.UserId != 0 && !string.IsNullOrWhiteSpace(seleccionarRolViewModel.RolCodigo))
            {
                //Verificar q la cuenta no este asignada a otro usuario
                Usuario usuario = _repository.Get(tokenResult.UserId);
                if (usuario != null)
                {
                    var result = AutentificarUsuario(usuario, null, seleccionarRolViewModel.RolCodigo);
                    return result;
                }
            }

            return StatusResponseHelper.JsonNoAutenticado("El usuario o el Rol seleccionado no esta asociado", false);
        }

        /// <summary>
        /// Autentificar usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="ipClient"></param>
        /// <param name="codigoRol"></param>
        /// <returns></returns>
        private JsonResult AutentificarUsuario(Usuario usuario, string ipClient, string codigoRol)
        {
            try
            {
                //TODO. JSA. Revisar el flujo si al momento de seleccionar un rol, este es externo, Por lo tanto no lo va tener asociado 
                //al usuario.  (Fallas Seguridad)
                //opcion 1. Sincrionizar rol_usuario, (externoas y internos) 
                //opcion 2. Pasar informacion en el model de la vista tipo (externo y interno), si es un rol externo pasar si verificacion o 
                //recuperar de una sesion los roles externos del usuario 

                JsonResult result;

                Rol rol = _rolService.GetList().Where(c => c.Codigo == codigoRol).FirstOrDefault();

                if (rol == null)
                {
                    string error = string.Format("No existe el rol con el codigo {0}", codigoRol);
                    result = StatusResponseHelper.JsonNoAutenticado(error, false);
                    return result;
                }

                if (!rol.EsExterno)
                {
                    rol = usuario.Roles.Where(c => c.Codigo == codigoRol).SingleOrDefault();

                    if (rol == null)
                    {
                        string error = string.Format("El usuario {0}, no tiene asociado el rol con el codigo {1}", usuario.Cuenta, codigoRol);
                        result = StatusResponseHelper.JsonNoAutenticado(error, false);
                        return result;
                    }
                }


                //Autentificar usuario 
                //Obtener la direccion IP del cliente 
                string ipAddress = ipClient;
                if (string.IsNullOrWhiteSpace(ipAddress))
                {
                    ipAddress = RequestHelpers.GetClientIpAddress(this.HttpContext.Request);
                }

                var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);
                var minutosExpiracionToken = Convert.ToInt32(AppSettings.Get<string>(ConstantesWebConfig.TOKEN_TIEMPOSESION));

                InitializeUserAccessServiciosWeb initializeUserAccessServiciosWeb = new InitializeUserAccessServiciosWeb();

                initializeUserAccessServiciosWeb.usuario = usuario;
                initializeUserAccessServiciosWeb.rol = rol;
                initializeUserAccessServiciosWeb.ipAddress = ipAddress;

                _accessService.InitializeUserAccess(initializeUserAccessServiciosWeb);

                var sesion = _application.GetCurrentSession();

                var token = Token.GenerateToken(Base64.Encode(claveEncriptar), usuario.Id, rol.Id, sesion.Id, minutosExpiracionToken);

                //FormsAuthentication.SetAuthCookie(usuario.Cuenta, false);

                var mensaje =
                    string.Format("El usuario {0}, ingresa de forma exitosa al sistema", usuario);
                //Registro Auditoria - Hora de inicio de sesión en el sistema.
                logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGIN, mensaje);

                //Direccionar a la URL segun la configuración del ROL, o direccionar a URL Default
                //string URL = FormsAuthentication.DefaultUrl;
                //if (!string.IsNullOrWhiteSpace(rol.Url))
                //{
                //    URL = rol.Url;
                //}

                /*var miFarmacia = _iFarmaciaService.GetMisFarmacias().Select(mf => mf.Farmacia).FirstOrDefault();
                String fileBase64 = miFarmacia == null || miFarmacia.Logo == null
                    || (!rol.Codigo.Equals(ConstantesRoles.ROL_FARMACEUTICO_PROPIETARIO) && !rol.Codigo.Equals(ConstantesRoles.ROL_FARMACEUTICO2)) ?
                    null : DataUrl.FromFileTypeAndBytes(miFarmacia.FileTypeLogo, miFarmacia.Logo);*/

                var rolView = new { codigoRol = rol.Codigo, rolNombre = rol.Nombre, rolEsadministrador = rol.EsAdministrador };
                var usuarioView = new
                {
                    usuId = usuario.Id,
                    version = usuario.VersionRegistro,
                    usuNombres = usuario.Nombres,
                    usuApellidos = usuario.Apellidos,
                    usuIdentificacion = usuario.PersonaId,
                    usuDireccion = "",
                    usuUsuario = usuario.Cuenta,
                    usuClave = "",
                    usuCorreo = usuario.Correo,
                    usuEstado = usuario.Estado,
                    //ImagenPerfil = fileBase64
                };

                result = new JsonResult
                {
                    Data = new
                    {
                        mensaje,
                        rol = rolView,
                        usuario = usuarioView,
                        miToken = token,
                        autenticado = true
                    },
                    //ContentType = contentType,
                    //ContentEncoding = contentEncoding,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return result;
            }
            catch (Exception ex)
            {
                var result = ManejadorExcepciones.HandleException(ex);

                //TODO: DEPENDENCIAS DE REINICIAR. MEJOR GUARDAR EN SESSION LA IDENTIDAD 
                FormsAuthentication.SignOut();

                Session.Clear();

                var result1 = StatusResponseHelper.JsonErrorServidor(result.Message, true);
                return result1;
            }
        }

        [HttpPost]
        public JsonResult Salir(SalirModeloVista obj)
        {
            string token = obj.valor;
            if (!string.IsNullOrEmpty(token))
            {
                var claveEncriptar = Base64.Encode(AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION));
                var tokenResult = Token.DecodeToken(claveEncriptar, token);
                var _repository = ServiceLocator.Current.GetInstance<IUsuarioRepository<Usuario>>();
                var _repositorySesion = ServiceLocator.Current.GetInstance<IRepository<Sesion>>();

                if (tokenResult.SesionId == -1)
                {
                    //TODO: DEPENDENCIAS DE REINICIAR. MEJOR GUARDAR EN SESSION LA IDENTIDAD 
                    FormsAuthentication.SignOut();

                    return Json(true);
                }

                var usuario = _repository.Get(tokenResult.UserId);
                var sesion = _repositorySesion.Get(tokenResult.SesionId);

                var msg =
                        string.Format("El usuario {0}, registra su salida del sistema.", usuario);
                //Registro Auditoria - Hora en que cerro sesión en el sistema.
                logAuditoria.Write(FUNCIONALIDAD_GESTION_USUARIOS.ACCION_LOGOUT, msg);

                EndUserAccessServiciosWeb iEndUserAccess = new EndUserAccessServiciosWeb();

                iEndUserAccess.usuario = usuario;
                iEndUserAccess.sesion = sesion;

                _accessService.EndUserAccess(iEndUserAccess);
            }

            //TODO: DEPENDENCIAS DE REINICIAR. MEJOR GUARDAR EN SESSION LA IDENTIDAD 
            FormsAuthentication.SignOut();

            return Json(true);

        }


        public ActionResult Ayuda()
        {

            //string UrlAyuda = FormsAuthentication.DefaultUrl;
            string UrlAyuda = string.Empty;
            try
            {
                Rol rol = _application.GetCurrentRol();
                var parametrosRol = JsonConvert.DeserializeObject<RolParametrosDTO>(rol.Parametros);
                if (parametrosRol != null)
                {
                    UrlAyuda = _parametroService.GetValor<string>(parametrosRol.CodParametroUrlAyuda);
                    return Redirect(UrlAyuda);
                }

            }
            catch (Exception ex)
            {
                var result = ManejadorExcepciones.HandleException(ex);
            }

            return null;
        }

        public JsonResult RecuperarCredencial(RecuperarCredencialModeloVista cuenta)
        {
            string plantilla = string.Empty;
            switch (cuenta.accion)
            {
                case 0: plantilla = ConstantesPlantillas.RUTA_PLANTILLA_RECUPERACION_CLAVE; break;
                case 1: plantilla = ConstantesPlantillas.RUTA_PLANTILLA_RECUPERACION_CUENTA; break;
                default: throw new Exception("No existe una implementacion para una accion: " + cuenta.accion);
            }
            var rutaPlantillaRecuperacion = Path.Combine(AppContext.BaseDirectory,
                         plantilla);

            var html = System.IO.File.ReadAllText(rutaPlantillaRecuperacion);

            var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);

            var persona = _repositoryPersona.GetQuery(p => p.Correo != null && p.Correo.Equals(cuenta.correo)).FirstOrDefault();

            if (persona == null)
            {
                throw new NegocioExcepcion("No existe una persona para el correo proporcionado.");
            }

            var usuario = _repository.GetByPersona(persona.Id);

            if (usuario == null)
            {
                throw new NegocioExcepcion("No existe una cuenta para el correo proporcionado.");
            }

            var sitioUrl = AppSettings.Get<string>(ConstantesWebConfig.SITIO_URL);

            switch (cuenta.accion)
            {
                case 0:
                    var token = TripleDES.Encode(JsonConvert.SerializeObject(new { Id = usuario.Id, Clave = usuario.Clave }), MD5.Encode(claveEncriptar));
                    html = string.Format(html, persona.ToString(), sitioUrl, Base64.EncodeUrl(token));
                    Mail.enviar(new List<string> { persona.Correo }, html, "Recuperación de clave");
                    break;
                case 1:
                    html = string.Format(html, persona.ToString(), usuario.Cuenta);
                    Mail.enviar(new List<string> { persona.Correo }, html, "Recuperación de Cuenta");
                    break;
                default: throw new Exception("No existe una implementacion para una accion: " + cuenta.accion);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: Farmacia/ConfirmacionCuenta
        [AllowAnonymous]
        public JsonResult CambiarClave(CambiarClaveModeloVista entidad)
        {
            var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);

            string json = string.Empty;
            try
            {
                json = TripleDES.Decode(Base64.DecodeUrl(entidad.param), MD5.Encode(claveEncriptar));
            }
            catch (System.Security.Cryptography.CryptographicException e)
            {
                throw new NegocioExcepcion("El link no tiene un formato adecuado.");
            }

            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);

            int usuarioId = obj.Id;
            string clave = obj.Clave;

            var usuario = _repository.Get(usuarioId);

            if (usuario.Clave.Equals(clave))
            {
                usuario.Clave = TripleDES.Encode(entidad.clave, MD5.Encode(claveEncriptar));
                _repository.SaveOrUpdate(usuario);
            }
            else
            {
                throw new NegocioExcepcion("Este link ya se utilizó para cambiar su clave.");
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

    public class SalirModeloVista
    {
        public string valor { get; set; }
    }

    public class RecuperarCredencialModeloVista
    {
        public string correo { get; set; }
        public int accion { get; set; }
    }

    public class CambiarClaveModeloVista
    {
        public string clave { get; set; }
        public string param { get; set; }
    }

}