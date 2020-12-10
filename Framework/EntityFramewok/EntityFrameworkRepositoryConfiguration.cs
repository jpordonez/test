namespace Framework.EntityFramewok
{
    //public class EntityFrameworkRepositoryConfiguration : IRepositoryConfiguration
    //{
    //    public void Configure(string ConnectionString, string dbSchema)
    //    {
    //        //var connection = new OracleConnection(ConnectionString);

    //        ObjectFactory.Configure(container =>
    //        {


    //            //container.For(typeof(DbConnection)).Singleton().Use(connection);

    //            //TODO: JSA, COMO SE DEBE MAPEAR ???
    //            //container.For(typeof(DbContext)).Singleton().Use(new ContextEntityFramework(dbSchema));
    //            container.For(typeof(DbContext)).Use(new ContextEntityFramework(dbSchema));


    //            //container.For(typeof(IRepository<>)).Singleton().Use(typeof(EntityFrameworkRepository<>));

    //            container.For(typeof(IRepository<>)).Use(typeof(EntityFrameworkRepository<>));

    //            //HttpContextScoped
    //            //container.For(typeof(IRepository<>)).HttpContextScoped().Use(typeof(EntityFrameworkRepository<>));

    //            //x.For(typeof(MyDbContext)).HttpContextScoped();
    //        });

    //        //For(typeof(DbContext)).Singleton().Use(new ContextEntityFramework(connection));

    //    }
    //}
}
