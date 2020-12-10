using System.Collections.Generic;
using Framework.Logging;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio.Recursos;

namespace Framework.Exception
{
    /// <summary>
    /// Clase para realizar un tratamiento de excepciones en base a EnterpriseLibrary
    /// </summary>
    public class ManejadorExcepciones : IHandlerExcepciones
    {
        /// <summary>
        /// Variable paraa realizar Log
        /// </summary>
        static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(ManejadorExcepciones));

        /// <summary>
        /// Lista de filtros aplicado 
        /// </summary>
        readonly List<IFilterHandleException> _filterHanderException;

        System.Exception _exception;
        System.Exception _innerException;

        string _mensaje = string.Empty;

        TypeResult _typeResultado = TypeResult.Error;

        ///<summary>
        ///</summary>
        ///<param name="filterHanderException"></param>
        public ManejadorExcepciones(List<IFilterHandleException> filterHanderException)
        {
            _filterHanderException = filterHanderException;
        }

        /// <summary>
        /// Indica el tipo de error producido
        /// </summary>
        public TypeResult TypeResultado
        {
            get { return _typeResultado; }
        }

        #region IManejadorExcepciones Members

        /// <summary>
        ///   Mensaje asociado al tipo de excepción
        /// </summary>
        public string Message
        {
            get { return _mensaje; }
        }

        /// <summary>
        /// Excepcion original interna
        /// </summary>
        public System.Exception InnerException
        {
            get { return _innerException; }
        }

        /// <summary>
        /// Excepcion resultado despues del tratamiento de excepciones
        /// </summary>
        public System.Exception Exception
        {
            get { return _exception; }
        }


        /// <summary>
        /// Manejar excepcion
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public HandleExceptionResult HandleException(System.Exception exception)
        {
            try
            {
                var result = new HandleExceptionResult();
                result.TypeResult = TypeResult.Error;
                result.Message = Mensajes.ErrorGenerico;

                //Aplicar tuberia de filtros para el tratamiento de errores, basado en la configuraciones
                foreach (var filter in _filterHanderException)
                    result = filter.HandleException(exception, result);

                _mensaje = result.Message;
                _typeResultado = result.TypeResult;
                //Registrar la excepcion en NLog
                log.Error("Excepcion:", exception);


                return result;
            }
            catch (System.Exception ex)
            {
                if (log != null)
                {
                    log.Error("Excepcion en ManejadorExcepciones - Exception Original :", exception);

                    //Registrar la excepcion en NLog
                    log.Error("Excepcion en ManejadorExcepciones :", ex);
                }
            }
            return null;
        }

        #endregion
    }
}
