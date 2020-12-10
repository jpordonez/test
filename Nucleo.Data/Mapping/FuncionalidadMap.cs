using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
    
    public class FuncionalidadMap :
        EntityTypeConfiguration<Funcionalidad>
    {
        public FuncionalidadMap()
        {
            ToTable("TSEG_FUNCIONALIDAD");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("FUN_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("FUN_CODIGO");
            Property(d => d.Nombre).HasColumnName("FUN_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("FUN_DESCRIPCION");
            Property(d => d.EstadoId).HasColumnName("FUN_ESTADOID");
            Property(d => d.Controlador).HasColumnName("FUN_CONTROLADOR");
            Property(d => d.SistemaId).HasColumnName("SIS_ID");


            HasRequired(c => c.Sistema).WithMany(s => s.Funcionalidades).HasForeignKey(m => m.SistemaId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
