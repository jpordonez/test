using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
    
    public class ParametroMap :
        EntityTypeConfiguration<ParametroSistema>
    {
        public ParametroMap()
        {
            ToTable("TADM_PARAMETROSISTEMA");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("PAR_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("PAR_CODIGO");
            Property(d => d.Nombre).HasColumnName("PAR_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("PAR_DESCRIPCION");

            Property(d => d.Categoria).HasColumnName("PAR_CATEGORIAID");
            Property(d => d.Tipo).HasColumnName("PAR_TIPOID");

            Property(d => d.Valor).HasColumnName("PAR_VALOR");
            Property(d => d.EsEditable).HasColumnName("PAR_ESEDITABLE");
            Property(d => d.TieneOpciones).HasColumnName("PAR_OPCIONES");
             

            Property(d => d.SistemaId).HasColumnName("SIS_ID");


            Property(d => d.FechaCreacion).HasColumnName("PAR_FECHA_CREACION");
            Property(d => d.FechaActualizacion).HasColumnName("PAR_FECHA_ACTUALIZACION");
            Property(d => d.UsuarioCreacionId).HasColumnName("PAR_USUARIO_CREACION_ID");
            Property(d => d.UsuarioActualizacionId).HasColumnName("PAR_USUARIO_ACTUALIZACION_ID");

            HasRequired(p => p.Sistema).WithMany(s => s.Parametros).HasForeignKey(p => p.SistemaId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
