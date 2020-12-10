namespace Framework.Security
{
    /// <summary>
    ///   Estereotipo: Interfase
    ///   Responsabilidad: Define métodos y propiedades para crear reglas de acceso
    /// </summary>
    public interface IAccessRule
    {
        /// <summary>
        /// Nombre de la regla
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Prioridad que se aplica a la regla
        /// </summary>
        int Priority { get; set; }

        /// <summary>
        /// Verificar si la regla cumple el criterio de aceptación 
        /// </summary>
        /// <param name="codigoSistema"></param>
        /// <param name="username"></param>
        void CheckRule(string username);
    }
}
