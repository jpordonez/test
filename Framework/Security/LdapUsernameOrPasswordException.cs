using System;
using Framework.Exception;

namespace Framework.Security
{
    ///<summary>
    /// Excepcion para notificar que el nombre de usuario o contraseña es invalido    
    ///</summary>
    [Serializable]
    public class LdapUsernameOrPasswordException : GenericException
    {
        ///<summary>
        ///</summary>
        ///<param name="message"></param>
        public LdapUsernameOrPasswordException(string message)
            : base(message, Resource.Ldap_NombreUsuarioContraseñaIncorrecto)
        {
        }

        ///<summary>
        ///</summary>
        public LdapUsernameOrPasswordException()
        {
            FriendlyMessage = Resource.Ldap_NombreUsuarioContraseñaIncorrecto;
        }

        public LdapUsernameOrPasswordException(System.Exception exception)
            : base(Resource.Ldap_NombreUsuarioContraseñaIncorrecto, exception, Resource.Ldap_NombreUsuarioContraseñaIncorrecto)
        {
            FriendlyMessage = Resource.Ldap_NombreUsuarioContraseñaIncorrecto;
        }

        public override string Message
        {
            get { return Resource.Ldap_NombreUsuarioContraseñaIncorrecto; }
        }
    }
}
