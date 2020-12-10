namespace Framework.Security
{
    /// <summary>
    ///   Estereotipo: Interfase
    ///   Responsabilidad: Define métodos y propiedades para un autorizador de acceso
    /// </summary>
    public interface IAccessAuthorizer
    {
        int RuleAccessCount { get; }

        /// <summary>
        /// Adiciona una regla para verificar
        /// </summary>
        /// <param name="rule"></param>
        void AppendAccessRule(IAccessRule rule);

        /// <summary>
        /// Verificar las reglas 
        /// </summary>
        /// <param name="username"></param>
        void CheckRules(string username);
    }
}
