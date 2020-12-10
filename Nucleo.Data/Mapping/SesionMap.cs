using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Data.EF.Mapping
{
      public class SesionMap :
        EntityTypeConfiguration<Sesion>
    {
          public SesionMap()
        {
            ToTable("TSEG_SESION");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("SES_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Cuenta).HasColumnName("SES_CUENTA");
            Property(d => d.Inicio).HasColumnName("SES_INICIO");
            Property(d => d.Fin).HasColumnName("SES_FIN");
            Property(d => d.EstadoId).HasColumnName("SES_ESTADOID");

            Property(d => d.IpAddress).HasColumnName("SES_IP");
            Property(d => d.RolId).HasColumnName("ROL_ID");


            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();

        }
    }
}
