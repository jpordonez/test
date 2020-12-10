using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
    public class CatalogoMap :
        EntityTypeConfiguration<Catalogo>
    {
        public CatalogoMap()
        {
            ToTable("TADM_CATALOGO");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("CAT_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("CAT_CODIGO");
            Property(d => d.Nombre).HasColumnName("CAT_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("CAT_DESCRIPCION");
            Property(d => d.SistemaId).HasColumnName("SIS_ID");

            Property(d => d.FechaCreacion).HasColumnName("CAT_FECHA_CREACION");
            Property(d => d.FechaActualizacion).HasColumnName("CAT_FECHA_ACTUALIZACION");
            Property(d => d.UsuarioCreacionId).HasColumnName("CAT_USUARIO_CREACION_ID");
            Property(d => d.UsuarioActualizacionId).HasColumnName("CAT_USUARIO_ACTUALIZACION_ID");


            HasRequired(c => c.Sistema).WithMany(s => s.Catalogos).HasForeignKey(m => m.SistemaId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
