using System;

namespace Framework.Util
{
    /// <summary>
    /// Gestion de fechas y tiempos
    /// </summary>
    public interface IManagerDateTime
    {
        /// <summary>
        /// Obtener fecha y hora actual
        /// </summary>
        /// <returns></returns>
        DateTime Get();
    }
}
