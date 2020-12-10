using Framework.Cache;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Negocio.Proceso
{
    public static class SystemProcess
    {
       public static void Procesar()
       {
           var cacheManager =  ServiceLocator.Current.GetInstance<ICacheManager>();
           cacheManager.Flush();

           Console.WriteLine("Cache Limpiado...");
       }
    }
}
