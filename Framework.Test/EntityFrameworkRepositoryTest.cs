using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Framework.Test
{
    [TestClass]
    public class EntityFrameworkRepositoryTest
    {

        [TestMethod]
        public void Cuando_Intenta_Guardar_Entidad_Nula_No_Permitir()
        {
            Mock<DbContext> dbContextMock = new Mock<DbContext>();

            //EntityFrameworkRepository<FooEntity> repository = new EntityFrameworkRepository<FooEntity>(dbContextMock.Object);

            try
            {
                //repository.SaveOrUpdate(null);
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentNullException), ex.GetType());
            }

            


        }
    }

    public class FooEntity : IEntity{


        public int Id { get; set; }
    }
}
