using System.Collections.Generic;
using System.Data.Entity;
using Framework.EntityFramewok;
using Framework.Repository;
using Framework.Service;
using Framework.Util;
using Negocio.Service;
using Nucleo.Data.EF;
using Nucleo.Dominio;
using Nucleo.Presentacion;
using Nucleo.Presentacion.Models;
using Nucleo.Service;
using StructureMap;
using Framework.Extensions;

namespace Negocio.Api.DependencyResolution
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public void Configure(string ConnectionString, string dbSchema)
        {
            List<IMappingConfiguration> config = new List<IMappingConfiguration>();
            config.Add(new MappingConfiguration());

            ObjectFactory.Configure(container =>
            {



                //TODO: JSA, el objeto udlaContext cuando debe crearse?
                //Singleton, no puede ya que mantiene todas las entidades 

                //container.For(typeof(DbContext)).LifecycleIs(InstanceScope.PerRequest).Use(new UdlaContext(config));
                //container.For(typeof(DbContext)).LifecycleIs(InstanceScope.Transient).Use(typeof(UdlaContext)); //new UdlaContext(config));
                //container.For(typeof(DbContext)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(UdlaContext)); //new UdlaContext(config));
                container.For(typeof(DbContext)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Contexto));

                container.For(typeof(IRepository<>)).Use(typeof(EntityFrameworkRepository<>));
                container.For(typeof(IRepositoryNamed<>)).Use(typeof(EntityFrameworkRepositoryNamed<>));

                //Repositorio para acceder a procedimientos almacenados
                container.For(typeof(IStoreProcedureRepository<>)).Use(typeof(EntityFrameworkStoreProcedureRepository<>));

                //Repositorios Personalizados
                container.For(typeof(IUsuarioRepository<>)).Use(typeof(EntityFrameworkUsuarioRepository<>));
                container.For(typeof(ISesionRepository<>)).Use(typeof(EntityFrameworkSesionRepository));
                container.For(typeof(IAuditoriaRepository<>)).Use(typeof(EntityFrameworkAuditoriaRepository));

                ///NO FUNCIONA EN OTRO LADO
                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                //IRepositoryNamed<Sistema> repositorySistem, IUsuarioRepository<Usuario> repositoryUser
                //container.For(typeof(IApplication)).Singleton().Use(typeof(GenericApplication));
                container.For(typeof(IApplication)).LifecycleIs(InstanceScope.Hybrid).Use(typeof(GenericServiciosWebApplication));

                container.For(typeof(IElmahExtension)).LifecycleIs(InstanceScope.Singleton).Use(typeof(ElmahExtension));

                ///TODO: JSA. INYECCION POR DEFAULT

                ///NO FUNCIONA EN OTRO LADO
                //container.For(typeof(IAccessService)).Singleton().Use(typeof(AccessServiceWeb));
                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(IAccessService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(AccessServiceServiciosWeb));

                ///NO FUNCIONA EN OTRO LADO
                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                //container.For(typeof(IParametroService)).Singleton().Use(typeof(ParametroService));
                container.For(typeof(IParametroService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(ParametroService));


                ///NO FUNCIONA EN OTRO LADO
                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                //container.For(typeof(IFuncionalidadService)).Singleton().Use(typeof(FuncionalidadService));
                container.For(typeof(IFuncionalidadService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(FuncionalidadService));

                ///NO FUNCIONA EN OTRO LADO
                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                //container.For(typeof(IAuthorizationService)).Singleton().Use(typeof(AuthorizationService));
                container.For(typeof(IAuthorizationService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(AuthorizationService));

                ///NO FUNCIONA EN OTRO LADO
                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(ICatalogoService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(CatalogoService));

                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(IRolService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(RolService));

                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(IPersonaService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(PersonaService));

                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(IInstitucionService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(InstitucionService));

                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(IMetaDataPaginacionServicio)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(MetaDataPaginacionServicio));

                //TODO: JSA no se puede utilizar Singleton() por los repositorios que mantienen el contexto en memoria
                container.For(typeof(IUsuarioService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(UsuarioService));
                                
                container.For(typeof(IMenuService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(MenuService));

                container.For(typeof(ISesionService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(SesionService));
                
                //container.For(typeof(ISitioService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(SitioService));

                //Negocio               

                container.For(typeof(IAsignacionDocenteService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(AsignacionDocenteService));
                container.For(typeof(IComponenteEducativoService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(ComponenteEducativoService));
                container.For(typeof(IMatriculaService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(MatriculaService));
                container.For(typeof(IResultadoService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(ResultadoService));

                //Para inyectar el contador de palabras
                container.For(typeof(IWordCounting)).Use(typeof(RegexWordCounting));

            });

        }

    }

}