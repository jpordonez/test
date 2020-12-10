using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
    public class EjecucionProcesoMap : EntityTypeConfiguration<EjecucionProceso>
    {
        public EjecucionProcesoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("TBAT_EJECUCION_PROCESO");
            this.Property(t => t.Id).HasColumnName("EPR_ID");
            this.Property(t => t.FechaEjecucion).HasColumnName("EPR_FECHA_EJECUCION");
            this.Property(t => t.CodigoProceso).HasColumnName("EPR_CODIGO").HasMaxLength(20);
            this.Property(t => t.UltimaEjecucion).HasColumnName("EPR_ULTIMA_EJECUCION");
            this.Property(t => t.Estado).HasColumnName("EPR_ESTADO");
            this.Property(t => t.UsuarioCreacion).HasColumnName("EPR_USUARIO_CREACION").IsOptional();
            this.Property(t => t.Parametros).HasColumnName("EPR_PARAMETROS").IsOptional();
            this.Property(t => t.Observacion).HasColumnName("EPR_OBSERVACION").IsOptional();

            //Propiedades Requeridas
            this.Property(t => t.CodigoProceso).IsRequired();

        }
    }
}
