using System;
using Framework.Repository;
using Framework.Security;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    public class AccessServiceServiciosWeb : IAccessService
    {
        private IApplication _application;
        private IAccessAuthorizer _accessAuthorizer;
        private IUsuarioRepository<Usuario> _repositoryUser;
        private IRepository<Sesion> _repositorySesion;

        public AccessServiceServiciosWeb(IApplication application, IAccessAuthorizer accessAuthorizer, IUsuarioRepository<Usuario> repositoryUser, IRepository<Sesion> repositorySesion)
        {
            _application = application;
            _accessAuthorizer = accessAuthorizer;
            _repositoryUser = repositoryUser;
            _repositorySesion = repositorySesion;
        }



        /// <summary>
        ///  Inicia la acceso de un usuario al sistema
        /// </summary>
        /// <param name="usuario">usuario con el inicio la sesion </param>
        /// <param name="rol">rol con el que inicio la sesion</param>
        /// <param name="ipAddress">direccion Ip del usuario que inicio la sesion</param>
        public void InitializeUserAccess(IInitializeUserAccess iInitializeUserAccess)
        {
            //Usuario usuario, Rol rol, string ipAddress
            //TOD: JSA, ESTO ES UN FLUJO DE AUTENTIFICACION DEL SISTEMA
            //1. APLICAR LAS REGLAS DE ACCESO
            //2. INICIALIZA PRINCIPAL
            //3. Iniciar sesion

            var initializeUserAccessServiciosWeb = iInitializeUserAccess as InitializeUserAccessServiciosWeb;

            if (initializeUserAccessServiciosWeb == null)
            {
                throw new ArgumentNullException("initializeUserAccessWeb");
            }

            var usuario = initializeUserAccessServiciosWeb.usuario;
            var rol = initializeUserAccessServiciosWeb.rol;
            var ipAddress = initializeUserAccessServiciosWeb.ipAddress;

            _accessAuthorizer.CheckRules(usuario.Cuenta);


            Sesion sesion = new Sesion();
            sesion.Cuenta = usuario.Cuenta;
            sesion.Inicio = DateTime.Now;
            sesion.EstadoId = EstadoSesion.Iniciada;
            sesion.RolId = rol.Id;
            sesion.IpAddress = ipAddress;

            sesion = _repositorySesion.SaveOrUpdate(sesion);

            //Establecer objetos de acceso 
            _application.SetCurrentUser(usuario);
            _application.SetCurrentRol(rol);
            _application.SetCurrentSession(sesion);

        }


        public void EndUserAccess(IEndUserAccess iEndUserAccess)
        {
            var endUserAccessWeb = iEndUserAccess as EndUserAccessServiciosWeb;

            if (endUserAccessWeb == null)
            {
                throw new ArgumentNullException("endUserAccessServiciosWeb");
            }

            var usuario = endUserAccessWeb.usuario;

            var sesion = endUserAccessWeb.sesion;
            sesion.Fin = _application.getDateTime();
            sesion.EstadoId = EstadoSesion.Finalizada;

            sesion = _repositorySesion.SaveOrUpdate(sesion);

        }
    }
}
