using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Menus;

namespace Nucleo.Data.EF.Mapping
{
    public class MenuItemMap :
        EntityTypeConfiguration<MenuItem>
    {
        public MenuItemMap()
        {
            ToTable("TSEG_MENUSITEM");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("MIT_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("MIT_CODIGO");
            Property(d => d.Nombre).HasColumnName("MIT_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("MIT_DESCRIPCION");
            Property(d => d.EstadoId).HasColumnName("MIT_ESTADOID");
            Property(d => d.TipoId).HasColumnName("MIT_TIPOID");
            Property(d => d.Url).HasColumnName("MIT_URL");

            Property(d => d.Icono).HasColumnName("MIT_ICONO");
            Property(d => d.Orden).HasColumnName("MIT_ORDEN");

            Property(d => d.MenuId).HasColumnName("MEN_ID");
            Property(d => d.PadreCodigo).HasColumnName("PADRE_CODIGO");
            Property(d => d.FuncionalidadId).HasColumnName("FUN_ID");

            //Relationships
            this.HasRequired(t => t.Menu)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.MenuId)
                //Para habilitar el eliminado en cascada
                .WillCascadeOnDelete(true);

            //TODO: JSA revisar como mapear 
            //this.HasOptional(e => e.Funcionalidad).WithOptionalDependent().Map(d => d.MapKey("FUN_ID")); //.Map( d => d.MapKey("jc"));


            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
