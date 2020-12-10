using System.Collections.Generic;
using System.Data.Entity;
using Framework.Logging;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;

namespace Framework.EntityFramewok
{
    /// <summary>
    /// Contexto Generico
    /// </summary>
    public class EntityFrameworkContext : DbContext
    {

        static readonly ILogger log =
         ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(EntityFrameworkContext));


        private string _DbSchema;

        private List<IMappingConfiguration> _mappingConfiguration;

        public EntityFrameworkContext() {

          

        }

        public EntityFrameworkContext(List<IMappingConfiguration> mappingConfiguration)
        {
            _mappingConfiguration = mappingConfiguration;
           
        }


        public EntityFrameworkContext(IMappingConfiguration mappingConfiguration,string dbSchema)
        {
            _DbSchema = dbSchema;
        }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);


            foreach (var item in _mappingConfiguration)
            {

                foreach (var assembly in item.GetAssemblyWithMapper())
                {

                    modelBuilder.Configurations.AddFromAssembly(assembly);
                }

                //TODO: Ver como se agregar EntityTypeConfiguration directamente 
                //foreach (var mapper in item.GetMapper())
                //{
                //    modelBuilder.Configurations.Add(mapper);
                //}
            }
        }
    }
}
