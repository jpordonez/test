using System;
using System.Collections.Generic;
using System.Reflection;

namespace Framework.Repository
{
    /// <summary>
    /// Interfaz para obtener mapeos para los ORM
    /// </summary>
    public interface IMappingConfiguration
    {

        /// <summary>
        /// Obtener listado de clases de mapeo de ORM
        /// </summary>
        /// <returns></returns>
        List<Type> GetMapper();

        /// <summary>
        /// Obtener listado de ensambladores que poseen mapeos de ORM
        /// </summary>
        /// <returns></returns>
        List<Assembly> GetAssemblyWithMapper();

    }
}
