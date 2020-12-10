namespace Framework.Exception
{
    /// <summary>
    /// Exception lanzada cuando una clave en AppSettings no se encuentra establecido
    /// </summary>
    public class AppSettingNotFoundException : GenericException
    {
        public AppSettingNotFoundException(string key)
            : base(string.Format("La clave [{0}], no se encuentra establecido en AppSetting", key), string.Format("La clave [{0}], no se encuentra establecido en AppSetting", key))
        {
        }

    }
}
