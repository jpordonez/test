using System;
using System.Web;
using Framework;
using Framework.Exception;
using Framework.Repository;
using Framework.Util;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Seguridad;
using Framework.Constantes;
using Negocio.Dominio.Models;
using System.Linq;

namespace Nucleo.Presentacion
{
    /// <summary>
    /// Manejo global de la aplicación
    /// </summary>
    public sealed class GenericServiciosWebApplication : IApplication
    {
        private readonly IUsuarioRepository<Usuario> _repositoryUser;
        private readonly IRepositoryNamed<Sistema> _repositorySistem;        
        private readonly IManagerDateTime _managerDateTime;
        private Usuario _usuario;
        private Rol _rol;
        private Dominio.Seguridad.Sesion _sesion;

        /// <summary>
        /// Guarda una instancia del sistema. Singleton
        /// </summary>
        private static Sistema _sistema;


        public GenericServiciosWebApplication(IManagerDateTime managerDateTime,
                                                IRepositoryNamed<Sistema> repositorySistem,
                                                IUsuarioRepository<Usuario> repositoryUser)
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

            if (_usuario == null)
                return false;
            if (_rol == null)
                return false;

            return true;
        }


        /// <summary>
        /// Obtiene la informacion del usuario autenticado
        /// </summary>        
        public Usuario GetCurrentUser()
        {
            if (_usuario != null)
            {
                return _usuario;
            }
            else
            {
                string error = string.Format("Usuario no autenticado.");
                throw new Exception(error);
            }
        }

        /// <summary>
        /// Establecer el usuario actual
        /// </summary>
        /// <param name="usuario"></param>
        public void SetCurrentUser(Usuario usuario)
        {
            Guard.AgainstArgumentNull(usuario, "GenericServiciosWebApplication.usuario");
            _usuario = usuario;
        }

        /// <summary>
        /// Obtiene la actual sesion de acceso del usuario
        /// </summary>
        /// <returns></returns>
        public Dominio.Seguridad.Sesion GetCurrentSession()
        {
            if (_sesion != null)
            {
                return _sesion;
            }
            else
            {
                string error = string.Format("No se encuentra iniciada la session del usuario {0}", GetCurrentUser().Cuenta);
                throw new Exception(error);
            }
        }



        /// <summary>
        /// Establece la sesion actual 
        /// </summary>
        /// <param name="sesion"></param>
        public void SetCurrentSession(Dominio.Seguridad.Sesion sesion)
        {
            Guard.AgainstArgumentNull(sesion, "GenericServiciosWebApplication.sesion");
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

                var codigoSistema = AppSettings.Get<string>(ConstantesWebConfig.CODIGO_SISTEMA);
                if (string.IsNullOrWhiteSpace(codigoSistema))
                {
                    string error = string.Format("No se puede iniciar el sistema, no existe la entrada [{0}] en la configuración correspondiente al codigo del sistema en los archivos de configuracion. Ejemplo web.config", ConstantesWebConfig.CODIGO_SISTEMA);
                    throw new GenericException(error, error);
                }
                _sistema = _repositorySistem.Get(codigoSistema);

                if (_sistema == null)
                {
                    string error = string.Format("No existe el registro de información del sistema, con el codigo  [{0}], verificar la configuración ", codigoSistema);
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
            Guard.AgainstArgumentNull(sistema, "GenericServiciosWebApplication.sistema");
            _sistema = sistema;
        }


        /// <summary>
        /// Obtener el actual Rol Autentificado
        /// </summary>
        /// <returns></returns>
        public Rol GetCurrentRol()
        {
            Guard.AgainstArgumentNull(_rol, "GenericServiciosWebApplication._rol");
            return _rol;
        }

        /// <summary>
        /// Establecer el rol autentificado
        /// </summary>
        /// <param name="sistema"></param>
        public void SetCurrentRol(Rol rol)
        {
            Guard.AgainstArgumentNull(rol, "GenericServiciosWebApplication._rol");
            _rol = rol;
        }

        /// <summary>
        /// Obtener el fecha y tiempo 
        /// </summary>
        /// <returns></returns>
        public DateTime getDateTime()
        {
            return _managerDateTime.Get();
        }        

    }
}