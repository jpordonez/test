using System;
using System.Collections.Generic;
using Framework.Cache;
using Framework.Exception;
using Framework.Logging;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service.Test
{
    [TestClass]
    public class AuthorizationServiceTest
    {
        [TestInitialize]
        public void Setup() {

            Mock<IServiceLocator> iserviceLocatorMock = new Mock<IServiceLocator>();
            Mock<ILoggerFactory> loggeerFactoryMock = new Mock<ILoggerFactory>();
            Mock<ILogger> ILoggerMock = new Mock<ILogger>();

            loggeerFactoryMock.Setup(m => m.Create(typeof(AuthorizationService))).Returns(ILoggerMock.Object);

            iserviceLocatorMock.Setup(m => m.GetInstance<ILoggerFactory>()).Returns(loggeerFactoryMock.Object);
            ServiceLocator.SetLocatorProvider(() => iserviceLocatorMock.Object);
        }

        [TestMethod]
        public void Rol_Administrador_Tiene_Todos_Permisos()
        {

            Rol rolAdministrador = new Rol();
            rolAdministrador.EsAdministrador = true;

         
            Mock<IApplication> applicationMock = new Mock<IApplication>();
            applicationMock.Setup(m => m.GetCurrentRol()).Returns(rolAdministrador);

            Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();
            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();
            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);

            var accion = new Accion();
            accion.Codigo = "Foo";

            var result = servicio.Authorize(accion);


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Inconsistencia_Rol_Actual_y_Lista_Roles()
        {

            Rol rolNormal = new Rol();
            rolNormal.EsAdministrador = false;
            rolNormal.Codigo = "foo";

            Usuario usr = new Usuario();
            usr.Cuenta = "foo";
            usr.Nombres = "foo";

            Mock<IApplication> applicationMock = new Mock<IApplication>();
            applicationMock.Setup(m => m.GetCurrentRol()).Returns(rolNormal);
            applicationMock.Setup(m => m.GetCurrentUser()).Returns(usr);


            Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();
            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();


            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);


            var accion = new Accion();
            accion.Codigo = "Foo";
            

             
            try
            {
                var result = servicio.Authorize(accion);

            }
            catch (Exception ex)
            {
                string error = string.Format("No se encuentra el rol con codigo {0} en la lista de roles", rolNormal.Codigo);

                Assert.AreEqual(typeof(GenericException),ex.GetType());

                Assert.AreEqual(ex.Message, error);
                
            }
        }

        [TestMethod]
        public void Rol_No_Tiene_Permisos()
        {
            
            
             Rol rolAdministrador = new Rol();
             rolAdministrador.Id = 1;
             rolAdministrador.EsAdministrador = true;
             rolAdministrador.Codigo = "bar";


            Rol rolNormal = new Rol();
            rolNormal.Id = 2;
            rolNormal.EsAdministrador = false;
            rolNormal.Codigo = "foo";

            Permiso permiso = new Permiso();
            permiso.AccionId = 1;
            permiso.RolId = 1;
            rolNormal.Permisos.Add(permiso);


            Usuario usr = new Usuario();
            usr.Cuenta = "foo";
            usr.Nombres = "foo";

            Mock<IApplication> applicationMock = new Mock<IApplication>();
            applicationMock.Setup(m => m.GetCurrentRol()).Returns(rolNormal);
            applicationMock.Setup(m => m.GetCurrentUser()).Returns(usr);


            Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();

            List<Rol> roles = new List<Rol>();
            roles.Add(rolNormal);
            roles.Add(rolAdministrador);

            repositoryRolMock.Setup(m => m.GetListIncluding(include => include.Permisos)).Returns(roles);

            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();

            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);


            var accion = new Accion();
            accion.Codigo = "Foo";
            accion.Id = 10;
 
            
            var result = servicio.Authorize(accion);

            Assert.IsFalse(result);
           
        }


        [TestMethod]
        public void Rol_Tiene_Permisos()
        {
         

            Rol rolAdministrador = new Rol();
            rolAdministrador.Id = 1;
            rolAdministrador.EsAdministrador = true;
            rolAdministrador.Codigo = "bar";


            Rol rolNormal = new Rol();
            rolNormal.Id = 2;
            rolNormal.EsAdministrador = false;
            rolNormal.Codigo = "foo";

            Permiso permiso = new Permiso();
            permiso.AccionId = 150;
            permiso.RolId = 1;
            rolNormal.Permisos.Add(permiso);


            Usuario usr = new Usuario();
            usr.Cuenta = "foo";
            usr.Nombres = "foo";

            Mock<IApplication> applicationMock = new Mock<IApplication>();
            applicationMock.Setup(m => m.GetCurrentRol()).Returns(rolNormal);
            applicationMock.Setup(m => m.GetCurrentUser()).Returns(usr);


            Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();

            List<Rol> roles = new List<Rol>();
            roles.Add(rolNormal);
            roles.Add(rolAdministrador);

            repositoryRolMock.Setup(m => m.GetListIncluding(include => include.Permisos)).Returns(roles);

            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();


            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);


            var accion = new Accion();
            accion.Codigo = "Foo";
            accion.Id = 150;


            var result = servicio.Authorize(accion);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Si_No_Existe_Codigo_Funcionalidad_No_Autorizar() {
           
            Mock<IApplication> applicationMock = new Mock<IApplication>();
           Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();
            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();

            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);



           var result =  servicio.Authorize("codigoFuncionalidad", "CodigoAccion");


           Assert.IsFalse(result);
        }

        [TestMethod]
        public void Si_No_Existe_Codigo_Accion_No_Autorizar()
        {
           
            Mock<IApplication> applicationMock = new Mock<IApplication>();
            Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();
            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();

            Funcionalidad fun = new Funcionalidad();
            fun.Codigo = "foo";
            List<Funcionalidad> lista = new List<Funcionalidad>();
            lista.Add(fun);

            funcionalidadServiceMock.Setup(m => m.GetFuncionalidades()).Returns(lista);

            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);


            var result = servicio.Authorize(fun.Codigo, "CodigoAccion");

            Assert.IsFalse(result);
        }

         [TestMethod]
        public void Si_Existe_Codigo_Funcionalidad_Codigo_Accion_Tiene_Permisos_Debe_Autorizar()
        {
          

            Rol rolAdministrador = new Rol();
            rolAdministrador.Id = 1;
            rolAdministrador.EsAdministrador = true;
            rolAdministrador.Codigo = "bar";


            Rol rolNormal = new Rol();
            rolNormal.Id = 2;
            rolNormal.EsAdministrador = false;
            rolNormal.Codigo = "foo";

            Permiso permiso = new Permiso();
            permiso.AccionId = 150;
            permiso.RolId = 1;
            rolNormal.Permisos.Add(permiso);


            Usuario usr = new Usuario();
            usr.Cuenta = "foo";
            usr.Nombres = "foo";

            Mock<IApplication> applicationMock = new Mock<IApplication>();
            applicationMock.Setup(m => m.GetCurrentRol()).Returns(rolNormal);
            applicationMock.Setup(m => m.GetCurrentUser()).Returns(usr);


            Mock<IRepository<Rol>> repositoryRolMock = new Mock<IRepository<Rol>>();

            List<Rol> roles = new List<Rol>();
            roles.Add(rolNormal);
            roles.Add(rolAdministrador);

            repositoryRolMock.Setup(m => m.GetListIncluding(include => include.Permisos)).Returns(roles);
              

            Mock<ICacheManager> cacheManagerMock = new Mock<ICacheManager>();
            Mock<IFuncionalidadService> funcionalidadServiceMock = new Mock<IFuncionalidadService>();

            Funcionalidad fun = new Funcionalidad();
            fun.Id = 10;
            fun.Codigo = "foo";

            var accion = new Accion();
            accion.Codigo = "Foo";
            accion.Id = 150;

            fun.Acciones.Add(accion);

            List<Funcionalidad> lista = new List<Funcionalidad>();
            lista.Add(fun);

            funcionalidadServiceMock.Setup(m => m.GetFuncionalidades()).Returns(lista);

            Mock<IRolService> rolServiceMock = new Mock<IRolService>();


            AuthorizationService servicio = new AuthorizationService(applicationMock.Object, repositoryRolMock.Object, cacheManagerMock.Object, funcionalidadServiceMock.Object, rolServiceMock.Object);


            var result = servicio.Authorize(fun.Codigo, accion.Codigo);

            Assert.IsTrue(result);


        }


    }
}
