using System;
using System.Web.Security;
using Framework.Logging;
using Framework.Security;
using Framework.Util;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;
using Framework.Constantes;

namespace Nucleo.Presentacion.Security
{
    /// <summary>
    /// Implementación para saltar la auttentificacion
    /// </summary>
    public class ByPassAuthentication : MembershipProvider
    {
        private IUsuarioRepository<Usuario> repository = ServiceLocator.Current.GetInstance<IUsuarioRepository<Usuario>>();
        //Logger de la aplicacion
        private static readonly ILogger Log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(ByPassActiveDirectoryMembershipProvider));

        //
        // keeps track of whether the provider has already been initialized
        //
        private bool initialized = false;

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            Log.Debug("Inicializando una instancia de ByPassAuthentication");

            base.Initialize(name, config);

            initialized = true;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = repository.Get(username);
            if (user == null)
            {
                return null;
            }
            return new MembershipUser(Name, username, user.Clave, user.Correo, "passwordQuestion", "comment", user.Estado.Equals(Estado.Activo), false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now); //, true /* valuesAreUpdated */);
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsCompareStrictUserName()
        {
            return true;
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            return true;
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var claveEncriptar = AppSettings.Get<string>(ConstantesWebConfig.CLAVE_ENCRYPTACION);
            var claveEncriptada = TripleDES.Encode(password, MD5.Encode(claveEncriptar));
            //throw new NegocioExcepcion("ClaveEncriptar: "+claveEncriptar + " y ClaveEncriptada: "+ claveEncriptada);
            var user = repository.Get(username);
            return user.Clave.Equals(claveEncriptada);
        }
    }
}
