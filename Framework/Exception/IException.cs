namespace Framework.Exception
{
    /// <summary>
    ///   Estereotipo: Interface
    ///   Responsabilidad: Define métodos y propiedades para construir excepciones personalizadas
    /// </summary>
    public interface IException
    {
        string FriendlyMessage { get; set; }
    }
}
