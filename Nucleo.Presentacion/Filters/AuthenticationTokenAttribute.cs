using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.WebPages;
using Framework.Repository;
using Framework.Util;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;
using Nucleo.Presentacion.Helpers;
using Nucleo.Presentacion.Models;
using Nucleo.Service;
using Framework.Constantes;

namespace Nucleo.Presentacion.Filters
{

    public class AuthenticationTokenAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {

            if (filterContext == null)
            {
                throw new ArgumentNullException("AuthenticationTokenAttribute");
            }


            //1. Saltar autorizacion, si el controlador o la accion tiene el atributo AllowAnonymousAttribute
            bool isAllowAnonymousAttribute =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
             || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                typeof(AllowAnonymousAttribute), inherit: true);


            if (isAllowAnonymousAttribute)
                return;

            string tokenHeader = filterContext.HttpContext.Request.Headers["token"];

            if (tokenHeader == null || tokenHeader.IsEmpty())
            {
                var error = string.Format("No Autorizado no se encontro un token.");
                var result = StatusResponseHelper.JsonNoAutenticado(error, false);
                filterContext.Result = result;
                return;
            }

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
                filterContext.Result = result;
                return;
            }

            var _application = ServiceLocator.Current.GetInstance<IApplication>();
            var _repository = ServiceLocator.Current.GetInstance<IUsuarioRepository<Usuario>>();

            Usuario usuario = _repository.Get(tokenResult.UserId);

            //Para indicar que no se ha seleccionado un rol
            if (tokenResult.RolId == -1)
            {
                var _rolesUsuario = usuario.Roles;
                var modelRol = new SeleccionarRolViewModel();
                foreach (var item in _rolesUsuario)
                {
                    var rolView = new RolViewModel() { CodigoRol = item.Codigo, NombreRol = item.Nombre };
                    modelRol.Roles.Add(rolView);
                }
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
                var result = StatusResponseHelper.JsonNoSeleccionadoRol("No se ha seleccionado un rol.", modelRol, usuarioView, tokenHeader);
                filterContext.Result = result;
                return;
            }

            var _rolService = ServiceLocator.Current.GetInstance<IRolService>();

            Rol rol = _rolService.Get(tokenResult.RolId);

            var _repositorySesion = ServiceLocator.Current.GetInstance<IRepository<Sesion>>();

            var sesion = _repositorySesion.Get(tokenResult.SesionId);

            if (usuario == null)
            {
                var result = StatusResponseHelper.JsonNoAutenticado("No existe usuario para el valor de token", false);
                filterContext.Result = result;
                return;
            }

            if (rol == null)
            {
                var result = StatusResponseHelper.JsonNoAutenticado("No existe rol para el valor de token", false);
                filterContext.Result = result;
                return;
            }

            if (sesion == null)
            {
                var result = StatusResponseHelper.JsonNoAutenticado("No existe sesion para el valor de token", false);
                filterContext.Result = result;
                return;
            }

            //Establecer objetos de acceso 
            _application.SetCurrentUser(usuario);
            _application.SetCurrentRol(rol);
            _application.SetCurrentSession(sesion);

            //TODO: JOR - Generar nuevo token con actualizacion de tiempo de creacion para la expiracion de sesiones
            var minutosExpiracionToken = Convert.ToInt32(AppSettings.Get<string>(ConstantesWebConfig.TOKEN_TIEMPOSESION));
            var token = Token.GenerateToken(claveEncriptar, usuario.Id, rol.Id, tokenResult.SesionId, minutosExpiracionToken);

            //JOR:Token actualizado para nuevas peticiones
            filterContext.HttpContext.Response.AppendHeader("token", token);

            //base.OnActionExecuting(filterContext);

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //var color = ((MyCustomPrincipal)filterContext.HttpContext.User).HairColor;
            //var user = filterContext.HttpContext.User;

            //if (!user.Identity.IsAuthenticated)
            //{
            //    filterContext.Result = new HttpUnauthorizedResult();
            //}
        }
    }

    public class MyPrincipal : GenericPrincipal
    {
        public MyPrincipal(IIdentity identity, string[] roles) : base(identity, roles)
        {


        }


    }


}
