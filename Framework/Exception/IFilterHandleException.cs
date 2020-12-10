namespace Framework.Exception
{
    /// <summary>
    /// Filtros aplicados en una tuberia para procesar excepcion
    /// </summary>
    public interface IFilterHandleException
    {
        /// <summary>
        /// Publica mensaje con la excepcion
        /// </summary>
        /// <param name="originalException"></param>
        /// <param name="result"></param>
        HandleExceptionResult HandleException(System.Exception originalException, HandleExceptionResult result);
    }
}
