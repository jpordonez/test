using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Data.EF.Mapping
{


    public class PermisoMap :
       EntityTypeConfiguration<Permiso>
    {
        public PermisoMap()
        {
            ToTable("TSEG_PERMISOS");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("PMI_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.RolId).HasColumnName("ROL_ID");
            Property(d => d.AccionId).HasColumnName("ACC_ID");
            Property(d => d.NoVisualizarEnMenu).HasColumnName("PMI_NO_VISUALIZAR_MENU");

            //Property(d => d).HasColumnName("ACC_CODIGO");
            //Property(d => d.Nombre).HasColumnName("ACC_NOMBRE");

            //Property(d => d.FechaCreacion).HasColumnName("PMI_FECHA_CREACION");
            //Property(d => d.FechaActualizacion).HasColumnName("PMI_FECHA_ACTUALIZACION");
            //Property(d => d.UsuarioCreacion).HasColumnName("PMI_USUARIO_CREACION_ID");
            //Property(d => d.UsuarioActualizacion).HasColumnName("PMI_USUARIO_ACTUALIZACION_ID");

            HasRequired(p => p.Rol).WithMany(r => r.Permisos).HasForeignKey(p => p.RolId);

            HasRequired(p => p.Accion).WithMany(r => r.Permisos).HasForeignKey(p => p.AccionId);

            //HasRequired(a => a.Accion).WithRequiredPrincipal();
            // HasRequired(a => a.Accion).WithRequiredDependent(); //(f => f..WithMany(f => f.Acciones).HasForeignKey(a => a.FuncionalidadId);

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();


        }
    }
}
