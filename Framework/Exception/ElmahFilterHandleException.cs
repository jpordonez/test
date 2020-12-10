using Framework.Extensions;
using Microsoft.Practices.ServiceLocation;

namespace Framework.Exception
{ 
    
    /// <summary>
    /// Filtro para utilizar elmah para trata la exception. Visualizar de excepciones, notificaciones por correo, todo el potencial del elmah
    /// </summary>
    public class ElmahFilterHandleException : IFilterHandleException
    {
        #region IFilterHandleException Members

        public HandleExceptionResult HandleException(System.Exception originalException, HandleExceptionResult result)
        {
            //JOR: No registro excepciones de negocio.
            if (originalException.GetType() == typeof(NegocioExcepcion))
            {
                return result;
            }

            var elmahExtension = ServiceLocator.Current.GetInstance<IElmahExtension>();
            //wrapper Elmah
            elmahExtension.LogToElmah(originalException);

            return result;
        }

        #endregion
    }
}
