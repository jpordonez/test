namespace Framework.TemplateEngine
{
    /// <summary>
    /// Estereotipo: Interfase
    /// Responsabilidad: Define el método para procesar una plantilla con su modelo
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="template">Nombre de la Plantilla</param>
        /// <param name="model">modelo que contiene los datos a mapearle a la plantilla</param>
        /// <returns></returns>
        string Process(string template, object model);
    }
}
