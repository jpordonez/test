using System;

namespace Framework.Reflection
{
    /// <summary>
    /// Creacion de Objetos utilizando clase Activator
    /// </summary>
    public class ActivatorCreateObjet : ICreateObject
    {
        #region ICreateObject Members

        public T CreateInstance<T>()
        {
            var obj = Activator.CreateInstance(typeof(T), true);
            return (T)obj;
        }

        #endregion
    }
}
