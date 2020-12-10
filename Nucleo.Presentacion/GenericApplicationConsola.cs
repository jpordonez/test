using System;
using System.Configuration;
using Framework;
using Framework.Exception;
using Framework.Repository;
using Framework.Security;
using Framework.Util;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Presentacion
{
    /// <summary>
    /// Manejo global de la aplicación consola
    /// </summary>
    public sealed class GenericApplicationConsola : IApplication
    {
        private IUsuarioRepository<Usuario> _repositoryUser;
        private IRepositoryNamed<Sistema> _repositorySistem;
        private IManagerDateTime _managerDateTime;

        private const string CLAVE_CONFIGURACION_CODIGO_SISTEMA = "Nucleo.Codigo_Sistema";

        private static Usuario _usuarioActual;
        private static Rol _rolActual;
        private static Dominio.Seguridad.Sesion _sesion;
        private static bool _esAutenticado;


        /// <summary>
        /// Guarda una instancia del sistema. Singleton
        /// </summary>
        private static Sistema _sistema;


        public GenericApplicationConsola(IManagerDateTime managerDateTime, IRepositoryNamed<Sistema> repositorySistem, IUsuarioRepository<Usuario> repositoryUser)
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

            if (!_esAutenticado)
                return false;

            if (_usuarioActual == null)
                return false;

            if (_rolActual == null)
                return false;

            return true;
        }

        public void SetIsAuthenticated(bool esAutenticado)
        {
            _esAutenticado = esAutenticado;
        }


        /// <summary>
        /// Obtiene la informacion del usuario autenticado
        /// </summary>        
        public Usuario GetCurrentUser()
        {

            //TODO: JSA, Revisar cual seria el flujo 
            if (!_esAutenticado)
                throw new GenericException("No se encuentra autentificado", "No se encuentra autentificado");


            //TODO. JSA, Usuario, traer con todos los roles ?? 
            if (_usuarioActual != null)
            {
                return _usuarioActual;
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

            _usuarioActual = usuario;

            if (_rolActual != null)
            {
                _esAutenticado = true;
            }
        }

        /// <summary>
        /// Obtiene la actual sesion de acceso del usuario
        /// </summary>
        /// <returns></returns>
        public Dominio.Seguridad.Sesion GetCurrentSession()
        {
            //TODO: JSA, Revisar cual seria el flujo 
            if (!_esAutenticado)
                throw new GenericException("No se encuentra autentificado", "No se encuentra autentificado");

            if (_sesion != null)
            {
                return _sesion;
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

            _sesion = sesion;

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

                var codigoSistema = AppSettings.Get<string>(CLAVE_CONFIGURACION_CODIGO_SISTEMA);
                if (string.IsNullOrWhiteSpace(codigoSistema))
                {
                    string error = string.Format("No se puede iniciar el sistema, no existe la entrada [0] en la configuración correspondiente al codigo del sistema en los archivos de configuracion. Ejemplo web.config", CLAVE_CONFIGURACION_CODIGO_SISTEMA);
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
            if (!_esAutenticado)
                throw new GenericException("No se encuentra autentificado", "No se encuentra autentificado");

            //TODO. JSA, Usuario, traer con todos los roles ?? 
            if (_rolActual != null)
            {
                return _rolActual;
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
            _rolActual = rol;
            if (_usuarioActual!=null)
            {
                _esAutenticado = true;
            }
        }

        public bool MostrarAyuda()
        {
            throw new NotImplementedException();
        }

        public bool MostrarRecuperacion()
        {
            throw new NotImplementedException();
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
