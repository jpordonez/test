using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{

 

    public class ItemCatalogoMap :
         EntityTypeConfiguration<ItemCatalogo>
    {
        public ItemCatalogoMap()
        {
            ToTable("TADM_ITEMCATALOGO");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("ITM_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Codigo).HasColumnName("ITM_CODIGO");
            Property(d => d.Nombre).HasColumnName("ITM_NOMBRE");
            Property(d => d.Descripcion).HasColumnName("ITM_DESCRIPCION");
            Property(d => d.CodigoCatalogo).HasColumnName("CAT_CODIGO");
            Property(d => d.CatalogoId).HasColumnName("CAT_ID");
            Property(d => d.Estado).HasColumnName("ITM_ESTADO");


            Property(d => d.FechaCreacion).HasColumnName("ITM_FECHA_CREACION");
            Property(d => d.FechaActualizacion).HasColumnName("ITM_FECHA_ACTUALIZACION");
            Property(d => d.UsuarioCreacionId).HasColumnName("ITM_USUARIO_CREACION_ID");
            Property(d => d.UsuarioActualizacionId).HasColumnName("ITM_USUARIO_ACTUALIZACION_ID");

            HasRequired(c => c.Catalogo).WithMany(s => s.Items); //.HasForeignKey(m => m.CatalogoId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
