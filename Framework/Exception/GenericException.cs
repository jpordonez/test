using System;

namespace Framework.Exception
{
    
    [Serializable]
    public class GenericException : System.Exception, IException
    {
        #region Implementation of IException

        public GenericException(string message, System.Exception innerException, string friendlyMessage)
            : base(message, innerException)
        {
            FriendlyMessage = friendlyMessage;
        }

        public string FriendlyMessage { get; set; }

        #endregion

        public GenericException(string message, string friendlyMessage)
            : base(message)
        {
            FriendlyMessage = friendlyMessage;
        }

        public GenericException()
        {
            FriendlyMessage = "Existe un inconveniente, por favor vuelva a intentar";
        }
    }
 
}
