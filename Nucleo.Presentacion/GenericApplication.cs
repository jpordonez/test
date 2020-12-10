using System;
using System.Configuration;
using System.Web;
using System.Web.WebPages;
using Framework;
using Framework.Exception;
using Framework.Repository;
using Framework.Security;
using Framework.Util;
using Newtonsoft.Json;
using Nucleo.Dominio;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Presentacion
{
    /// <summary>
    /// Manejo global de la aplicación
    /// </summary>
    public sealed class GenericApplication : IApplication
    {
        private IUsuarioRepository<Usuario> _repositoryUser;
        private IRepositoryNamed<Sistema> _repositorySistem;
        private IManagerDateTime _managerDateTime;

        private const string CLAVE_CONFIGURACION_CODIGO_SISTEMA = "UDLA.NUCLEO.CODIGO_SISTEMA";


        /// <summary>
        /// Guarda una instancia del sistema. Singleton
        /// </summary>
        private static Sistema _sistema;


        public GenericApplication(IManagerDateTime managerDateTime, IRepositoryNamed<Sistema> repositorySistem, IUsuarioRepository<Usuario> repositoryUser)
        {
            _repositorySistem = repositorySistem;
            _repositoryUser = repositoryUser;
            _managerDateTime = managerDateTime;
        }


        /// <summary>
        /// Verificar si la aplicacion esta autentificada
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticated()
        {

            if (HttpContext.Current == null)
                return false;

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return false;


            try
            {
                var user =
                    HttpContext.Current.Session[ConstantesSesionesSecurity.SESSION_USUARIO_AUTENTIFICADO] as Usuario;
                if (user == null)
                    return false;

                var rol = HttpContext.Current.Session[ConstantesSesiones.SESSION_ROL_AUTENTIFICADO] as Rol;
                if (rol == null)
                    return false;

            }
            catch (Exception)
            {
                HttpContext.Current.Response.RedirectToRoute(new { controller = "Cuenta", action = "Salir" });
                HttpContext.Current.Response.End();
            }


            return true;
        }


        /// <summary>
        /// Obtiene la informacion del usuario autenticado
        /// </summary>        
        public Usuario GetCurrentUser()
        {
            //TODO: JSA.  Pasar nullo el usuario, o lanzar excepcion 
            if (HttpContext.Current == null)
                throw new GenericException("No se encuentra autentificado, el objeto HttpContext.Current es nulo", "No se encuentra autentificado");


            //TODO: JSA, Revisar cual seria el flujo 
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new GenericException("No se encuentra autentificado", "No se encuentra autentificado");


            //TODO. JSA, Usuario, traer con todos los roles ?? 
            if (HttpContext.Current.Session[ConstantesSesionesSecurity.SESSION_USUARIO_AUTENTIFICADO] != null)
            {
                var usuarioSesion = HttpContext.Current.Session[ConstantesSesionesSecurity.SESSION_USUARIO_AUTENTIFICADO] as Usuario;

                return usuarioSesion;
            }

            throw new GenericException(string.Format("No se encuentra autentificado, la Session {0} es nula ", ConstantesSesionesSecurity.SESSION_USUARIO_AUTENTIFICADO), "No se encuentra autentificado");

            //return null;

            //TODO: JSA, No recuperar el usuario, se deberia establecer en el proceso de autentificado. 
            //Usuario usuario = null;

            //var CampoIdentidad = ManagerUser.CampoIdentidad;
            //if (CampoIdentidad == CamposIdentidadUsuario.Id)
            //    usuario = _repositoryUser.Get(Convert.ToInt32(HttpContext.Current.User.Identity.Name));

            //if (CampoIdentidad == CamposIdentidadUsuario.UserName)
            //    usuario = _repositoryUser.Get(HttpContext.Current.User.Identity.Name);


            //SetCurrentUser(usuario);

            //return usuario;
        }

        /// <summary>
        /// Establecer el usuario actual
        /// </summary>
        /// <param name="usuario"></param>
        public void SetCurrentUser(Usuario usuario)
        {
            Guard.AgainstArgumentNull(usuario, "GenericApplication.usuario");

            HttpContext.Current.Session[ConstantesSesionesSecurity.SESSION_USUARIO_AUTENTIFICADO] = usuario;
        }

        /// <summary>
        /// Obtiene la actual sesion de acceso del usuario
        /// </summary>
        /// <returns></returns>
        public Dominio.Seguridad.Sesion GetCurrentSession()
        {
            //TODO: JSA, Revisar cual seria el flujo 
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new GenericException("No se encuentra autentificado", "No se encuentra autentificado");

            if (HttpContext.Current != null && HttpContext.Current.Session[ConstantesSesiones.SESSION_SESSION] != null)
            {
                var usuarioSesion = HttpContext.Current.Session[ConstantesSesiones.SESSION_SESSION] as Dominio.Seguridad.Sesion;

                return usuarioSesion;
            }


            //TODO. JSA. Definir crear sesion o lanzar error que no ha sido creada
            //Sesion sesion = new Sesion();
            //sesion.Cuenta = usuario.Cuenta;
            //sesion.Inicio = DateTime.Now;
            //sesion.EstadoId = EstadoSesion.Iniciada;

            //sesion = _repositorySesion.SaveOrUpdate(sesion);

            //return usuario;

            string error = string.Format("No se encuentra iniciada la session del usuario {0}", GetCurrentUser().Cuenta);

            throw new GenericException(error, error);

        }



        /// <summary>
        /// Establece la sesion actual 
        /// </summary>
        /// <param name="sesion"></param>
        public void SetCurrentSession(Dominio.Seguridad.Sesion sesion)
        {

            HttpContext.Current.Session[ConstantesSesiones.SESSION_SESSION] = sesion;

        }


        /// <summary>
        /// Obtiene el actual sistema
        /// </summary>
        /// <returns></returns>
        public Sistema GetCurrentSistema()
        {

            //1. Recuperar sistema si no esta instanciado
            if (_sistema == null)
            {

                var codigoSistema = AppSettings.Get<string>(GenericApplication.CLAVE_CONFIGURACION_CODIGO_SISTEMA);
                if (string.IsNullOrWhiteSpace(codigoSistema))
                {
                    string error = string.Format("No se puede iniciar el sistema, no existe la entrada [0] en la configuración correspondiente al codigo del sistema en los archivos de configuracion. Ejemplo web.config", GenericApplication.CLAVE_CONFIGURACION_CODIGO_SISTEMA);
                    throw new GenericException(error, error);
                }
                _sistema = _repositorySistem.Get(codigoSistema);

                if (_sistema == null)
                {
                    string error = string.Format("No existe el registro de información del sistema, con el codigo  [0], verificar la configuración ", codigoSistema);
                    throw new GenericException(error, error);
                }

            }

            return _sistema;
        }



        /// <summary>
        /// Establece la sesion actual 
        /// </summary>
        /// <param name="sesion"></param>
        public void SetCurrentSistema(Sistema sistema)
        {
            _sistema = sistema;
        }


        /// <summary>
        /// Obtener el actual Rol Autentificado
        /// </summary>
        /// <returns></returns>
        public Rol GetCurrentRol()
        {
            //TODO: JSA, Revisar cual seria el flujo 
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                throw new GenericException("No se encuentra autentificado", "No se encuentra autentificado");

            //TODO. JSA, Usuario, traer con todos los roles ?? 
            if (HttpContext.Current != null && HttpContext.Current.Session[ConstantesSesiones.SESSION_ROL_AUTENTIFICADO] != null)
            {
                var rol = HttpContext.Current.Session[ConstantesSesiones.SESSION_ROL_AUTENTIFICADO] as Rol;

                return rol;
            }

            string error = string.Format("No se encuentra en la session el rol autentificado para el usuario [{0}]", GetCurrentUser().Cuenta);

            throw new GenericException(error, error);
        }

        /// <summary>
        /// Establecer el rol autentificado
        /// </summary>
        /// <param name="sistema"></param>
        public void SetCurrentRol(Rol rol)
        {
            HttpContext.Current.Session[ConstantesSesiones.SESSION_ROL_AUTENTIFICADO] = rol;
        }

        public bool MostrarAyuda()
        {
            bool retorno = false;
            Rol rol = GetCurrentRol();
            if (rol.Parametros == null)
            {
                return retorno;
            }
            var parametrosRol = JsonConvert.DeserializeObject<RolParametrosDTO>(rol.Parametros);
            if (parametrosRol == null) return retorno;
            if (!parametrosRol.CodParametroUrlAyuda.IsEmpty())
            {
                retorno = true;    
            }
            return retorno;
        }

        public bool MostrarRecuperacion()
        {
            bool retorno = false;
            Rol rol = GetCurrentRol();
            if (rol.Parametros == null)
            {
                return retorno;
            }
            var parametrosRol = JsonConvert.DeserializeObject<RolParametrosDTO>(rol.Parametros);
            if (parametrosRol == null) return retorno;
            if (!parametrosRol.CodParametroUrlRecuperacion.IsEmpty())
            {
                retorno = true;
            }
            return retorno;
        }


        /// <summary>
        /// Obtener el fecha y tiempo 
        /// </summary>
        /// <returns></returns>
        public DateTime getDateTime()
        {
            return _managerDateTime.Get();
        }

        public int GetUniversidadId()
        {
            throw new NotImplementedException();
        }
    }
}