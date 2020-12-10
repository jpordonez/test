namespace Framework.Exception
{
    /// <summary>
    /// Interfaz para realizar manejo de excepciones. Realizar log de las excepciones, convertir excepciones, personalizar mensajes
    /// </summary>
    public interface IHandlerExcepciones
    {
        /// <summary>
        ///   Mensaje asociado al tipo de excepción
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Excepcion original interna
        /// </summary>
        System.Exception InnerException { get; }

        /// <summary>
        /// Excepcion resultado despues del tratamiento de excepciones
        /// </summary>
        System.Exception Exception { get; }

        /// <summary>
        /// Manejar excepcion
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        HandleExceptionResult HandleException(System.Exception ex);
    }

    /// <summary>
    /// Resultado del manejo de excepciones
    /// </summary>
    public class HandleExceptionResult
    {
        /// <summary>
        /// Mensaje amigable al usuario
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Codigo interno, para categorizar el resultado
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Tipo de resultado del tratamiento de la excepcion
        /// </summary>
        public TypeResult TypeResult { get; set; }
    }


    /// <summary>
    /// Tipos de resultados de tratamiento de excepciones
    /// </summary>
    public enum TypeResult
    {
        /// <summary>
        /// Represents a error.
        /// </summary>
        Error,

        /// <summary>
        /// Represents a Warning displayed to the user
        /// </summary>
        Warning,

        /// <summary>
        /// Represents a Information be displayed to the user
        /// </summary>
        Information
    }
}
