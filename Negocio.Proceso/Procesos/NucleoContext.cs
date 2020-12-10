using System.Collections.Generic;
using System.Data.Entity;
using Nucleo.Dominio.Entidades;
using Framework.EntityFramewok;
using Framework.Repository;
using Nucleo.Dominio.Menus;
using Nucleo.Dominio.Seguridad;

namespace Negocio.Proceso
{
     
    public class NucleoContext : EntityFrameworkContext
    {
        public DbSet<Sistema> Sistemas { get; set; }

        public DbSet<Catalogo> Catalogos { get; set; }

        public DbSet<ItemCatalogo> ItemCatalogos { get; set; }

        public DbSet<Funcionalidad> Funcionalidades { get; set; }

        public DbSet<Accion> AccionesFuncionalidades { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuItem> MenusItems { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ParametroSistema> Parametros { get; set; }
        public DbSet<EjecucionProceso> EjecucionProceso { get; set; }

        public NucleoContext(List<IMappingConfiguration> mappingConfiguration)
            : base(mappingConfiguration)
        {

        }
    }
}
