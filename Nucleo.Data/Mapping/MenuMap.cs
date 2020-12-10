using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Menus;

namespace Nucleo.Data.EF.Mapping
{
     public class MenuMap :
        EntityTypeConfiguration<Menu>
    {
         public MenuMap()
        {
            ToTable("TSEG_MENU");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("MEN_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("MEN_CODIGO");
            Property(d => d.Nombre).HasColumnName("MEN_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("MEN_DESCRIPCION");
            Property(d => d.SistemaId).HasColumnName("SIS_ID");

            HasRequired(m => m.Sistema).WithMany(s => s.Menus).HasForeignKey(m => m.SistemaId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
