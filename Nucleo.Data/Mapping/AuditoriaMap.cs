using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
   

    public class AuditoriaMap :
      EntityTypeConfiguration<Auditoria>
    {
        public AuditoriaMap()
        {
            ToTable("TAUD_AUDITORIA");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("AUD_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Accion).HasColumnName("AUD_ACCION");
            Property(d => d.Fecha).HasColumnName("AUD_FECHA");
            Property(d => d.Funcionalidad).HasColumnName("AUD_FUNCIONALIDAD");
            Property(d => d.Identificacion).HasColumnName("AUD_IDENTIFICACION");
            Property(d => d.IpAddress).HasColumnName("AUD_DIRECCION_IP");
            Property(d => d.Mensaje).HasColumnName("AUD_MENSAJE");
            Property(d => d.Usuario).HasColumnName("AUD_USUARIO");

        }

       
    }
}
