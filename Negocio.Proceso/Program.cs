using System;
using System.Linq;
using StructureMap;
using Microsoft.Practices.ServiceLocation;
using Framework.Exception;
using Nucleo.Dominio;
using Framework.Repository;
using Nucleo.Dominio.Seguridad;
using Infrastructure.DependencyResolution;

namespace Negocio.Proceso
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = new OptionCommand();
                if (CommandLine.Parser.Default.ParseArguments(args, options))
                {

                    //1. IoC
                    IoC();

                    //2. Autentificacion
                    Autenticar(options);

                    //options.Action
                    var result = ProcesarAcciones.Run(options);

                    Environment.Exit(result);

                }
                else
                {

                    Console.WriteLine("No se proceso, existe un inconveniente");
                    Environment.Exit(Constantes.PROCESO_ERROR);
                }
            }
            catch (Exception ex)
            {

                var manejadorExcepciones = ServiceLocator.Current.GetInstance<IHandlerExcepciones>();
                manejadorExcepciones.HandleException(ex);

                Console.WriteLine(ex.Message);
            }
           
        }

        private static void Autenticar(OptionCommand options)
        {
            var _application = ServiceLocator.Current.GetInstance<IApplication>();
            var _repositoryUsuario = ServiceLocator.Current.GetInstance<IRepository<Usuario>>();
            var usuarioQuery = _repositoryUsuario.GetQuery<Usuario>();
            var usuario = usuarioQuery.FirstOrDefault(u => u.Cuenta == options.Usuario);
            if (usuario == null)
            {
                throw new GenericException("No existe el usuario: " + options.Usuario, "No existe el usuario: " + options.Usuario);
            }
            _application.SetCurrentUser(usuario);
            var rolAdmin = usuario.Roles.FirstOrDefault(r => r.Codigo == options.Rol);
            if (rolAdmin==null)
            {
                var mensaje = string.Format("El usuario: {0} no posee rol {1}, no se puede ejecutar el proceso", options.Usuario, options.Rol);
                throw new GenericException(mensaje,mensaje);
            }
            _application.SetCurrentRol(rolAdmin);
        }


        static void IoC() {
            ObjectFactory.Initialize(x => x.Scan(y =>
            {
                //The PullConfigurationFromAppConfig flag tells structure map to read the configuration file.
                x.PullConfigurationFromAppConfig = true;

                y.LookForRegistries();
            }));

            //Establecer el Service Locator con structureMap
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator());

            var configurationRepository = ServiceLocator.Current.GetInstance<IRepositoryConfiguration>();
            //Configuracion de Repositorios
            configurationRepository.Configure("", "");



        }
        
    }
}
