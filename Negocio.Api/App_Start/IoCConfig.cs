using System.Web.Http;
using System.Web.Mvc;
using Framework.DependencyResolution;
using Framework.Repository;
using Infrastructure.DependencyResolution;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Negocio.Api
{
    public static class IoCConfig
    {
        public static void Register()
        {

            ObjectFactory.Initialize(x => x.Scan(y =>
            {
                //The PullConfigurationFromAppConfig flag tells structure map to read the configuration file.
                x.PullConfigurationFromAppConfig = true;

                //Inyectar implementaciones basadas en las conveciones IFoo => Foo
                y.WithDefaultConventions();

                //Buscar por las clases Registers
                y.LookForRegistries();
            }));

            //Establecer el Service Locator con structureMap
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator());

            var configurationRepository = ServiceLocator.Current.GetInstance<IRepositoryConfiguration>();
            //Configuracion de Repositorios
            configurationRepository.Configure("", "");

            IContainer container = ObjectFactory.Container;

            //Establecer del Dependecy Resolver del MVC con StructureMap
            DependencyResolver.SetResolver(new SmMvcDependencyResolver(container));

            //Establecer del Dependecy Resolver del Web Api con StructureMap
            GlobalConfiguration.Configuration.DependencyResolver = new SmHttpDependencyResolver(container);

        }
    }
}