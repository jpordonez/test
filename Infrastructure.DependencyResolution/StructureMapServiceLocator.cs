using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Infrastructure.DependencyResolution
{
    public class StructureMapServiceLocator : IServiceLocator
    {
        #region IServiceLocator Members

        /// <summary>
        /// Obtiene una instancia de objeto registrada para el tipo serviceType
        /// </summary>
        /// <param name="serviceType">El tipo de objeto requerido</param>
        /// <returns>La instancia de objeto requerida</returns>
        public object GetService(Type serviceType)
        {
            return ObjectFactory.GetInstance(serviceType);
        }

        ///<summary>
        /// Obtiene una instancia de objeto registrada para el tipo serviceType
        ///</summary>
        /// <param name="serviceType">El tipo de objeto requerido</param>
        /// <returns>La instancia de objeto requerida</returns>
        public object GetInstance(Type serviceType)
        {
            return ObjectFactory.GetInstance(serviceType);
        }

        ///<summary>
        /// Obtiene una instancia de objeto registrada por key para el tipo serviceType
        ///</summary>
        /// <param name="serviceType">El tipo de objeto requerido</param>
        ///<param name="key">cadena de texto usada como clave para registrar la dependencia</param>
        /// <returns>La instancia de objeto requerida</returns>
        public object GetInstance(Type serviceType, string key)
        {
            return ObjectFactory.GetNamedInstance(serviceType, key);
        }

        ///<summary>
        /// Obtiene la lista de todas las instancias de objeto registradas para el tipo serviceType
        ///</summary>
        /// <param name="serviceType">El tipo de objeto requerido</param>
        /// <returns>La lista de instancias de objeto requeridas</returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            var instances = ObjectFactory.GetAllInstances(serviceType);
            return instances.Cast<object>().ToList();
        }

        ///<summary>
        /// Obtiene una instancia de objeto registrada para el tipo TService
        ///</summary>
        /// <param name="TService">El tipo de objeto requerido</param>
        /// <returns>La instancia de objeto requerida</returns>
        public TService GetInstance<TService>()
        {
            return ObjectFactory.GetInstance<TService>();
        }

        ///<summary>
        /// Obtiene una instancia de objeto registrada por key para el tipo TService
        ///</summary>
        /// <param name="TService">El tipo de objeto requerido</param>
        ///<param name="key">cadena de texto usada como clave para registrar la dependencia</param>
        /// <returns>La instancia de objeto requerida</returns>
        public TService GetInstance<TService>(string key)
        {
            return ObjectFactory.GetNamedInstance<TService>(key);
        }

        ///<summary>
        /// Obtiene la lista de todas las instancias de objeto registradas para el tipo TService
        ///</summary>
        ///<typeparam name="TService">El tipo de objeto requerido</typeparam>
        /// <returns>La lista de instancias de objeto requeridas</returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return ObjectFactory.GetAllInstances<TService>();
        }

        #endregion
    }
}
