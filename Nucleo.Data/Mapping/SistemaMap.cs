using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
     public class SistemaMap :
         EntityTypeConfiguration<Sistema>
    {
         public SistemaMap()
        {
            ToTable("TSEG_SISTEMA");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("SIS_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("SIS_CODIGO");
            Property(d => d.Nombre).HasColumnName("SIS_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("SIS_DESCRIPCION");

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();

        }
    }
}
