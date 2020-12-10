using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
    public class AccionMap :
        EntityTypeConfiguration<Accion>
    {


        public AccionMap()
        {
            ToTable("TSEG_ACCION"); 
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("ACC_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("ACC_CODIGO");
            Property(d => d.Nombre).HasColumnName("ACC_NOMBRE");
            Property(d => d.FuncionalidadId).HasColumnName("FUN_ID");

          
            HasRequired(a => a.Funcionalidad).WithMany(f => f.Acciones).HasForeignKey(a => a.FuncionalidadId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
