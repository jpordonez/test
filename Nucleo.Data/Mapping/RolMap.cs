using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Data.EF.Mapping
{
    public class RolMap :
         EntityTypeConfiguration<Rol>
    {
        public RolMap()
        {
            ToTable("TSEG_ROL");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("ROL_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("ROL_CODIGO");
            Property(d => d.Nombre).HasColumnName("ROL_NOMBRE");
            Property(d => d.EsAdministrador).HasColumnName("ROL_ESADMINISTRADOR");
            Property(d => d.EsExterno).HasColumnName("ROL_ESEXTERNO");
            Property(d => d.Url).HasColumnName("ROL_URL");
            Property(d => d.Parametros).HasColumnName("ROL_PARAMETROS");
            Property(d => d.FechaCreacion).HasColumnName("ROL_FECHA_CREACION");
            Property(d => d.FechaActualizacion).HasColumnName("ROL_FECHA_ACTUALIZACION");
            Property(d => d.UsuarioCreacionId).HasColumnName("ROL_USUARIO_CREACION_ID");
            Property(d => d.UsuarioActualizacionId).HasColumnName("ROL_USUARIO_ACTUALIZACION_ID");
            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();
        }
    }
}
