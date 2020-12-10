namespace Framework.TemplateEngine
{
    //public class CastleTemplateEngine : ITemplateEngine
    //{
    //    Castle.Components.Common.TemplateEngine.ITemplateEngine engine;

    //    public CastleTemplateEngine()
    //    {
    //        //string templatesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plantillas");
    //        //engine = new NVelocityTemplateEngine(templatesPath);
    //        engine = new NVelocityTemplateEngine();
    //        (engine as ISupportInitialize).BeginInit();
    //    }

    //    #region ITemplateEngine Members

    //    public string Process(string template, object model)
    //    {
    //        if (model == null) throw new NullReferenceException();
    //        if (string.IsNullOrEmpty(template)) throw new ArgumentException();

    //        string retval;

    //        using (var writer = new StringWriter())
    //        {
    //            IDictionary context = new Hashtable { { "Model", model } };

    //            engine.Process(context, "", writer, template);
    //            retval = writer.ToString();
    //        }

    //        return retval;
    //    }

    //    #endregion
    //}
}
