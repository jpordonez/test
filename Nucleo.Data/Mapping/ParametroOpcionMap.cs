using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
   
    public class ParametroOpcionMap :
        EntityTypeConfiguration<ParametroOpcion>
    {
        public ParametroOpcionMap()
        {
            ToTable("TADM_PARAMETRO_OPCIONES");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("POP_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Valor).HasColumnName("POP_VALOR");
            Property(d => d.Texto).HasColumnName("POP_TEXTO");

            Property(d => d.ParametroId).HasColumnName("PAR_ID");

            HasRequired(p => p.Parametro).WithMany(s => s.Opciones).HasForeignKey(p => p.ParametroId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();

        }
    }
}
