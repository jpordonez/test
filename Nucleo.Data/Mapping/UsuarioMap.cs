using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nucleo.Dominio.Seguridad;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF.Mapping
{
     public class UsuarioMap :
        EntityTypeConfiguration<Usuario>
    {
         public UsuarioMap()
        {
            ToTable("TSEG_USUARIO");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("USR_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(d => d.Cuenta).HasColumnName("USR_CUENTA");
            Property(d => d.PersonaId).HasColumnName("PER_ID");
            Property(d => d.Estado).HasColumnName("USR_ESTADO");
            Property(d => d.Clave).HasColumnName("USR_CLAVE");

            Property(d => d.VersionRegistro).HasColumnName("VERSION").IsConcurrencyToken();

            // Relationships
            this.HasMany(t => t.Roles)
                .WithMany(t => t.Usuarios)
                .Map(m =>
                {
                    m.ToTable("TSEG_USUARIO_ROL");                    
                    m.MapLeftKey("USR_ID");
                    m.MapRightKey("ROL_ID");
                });

            HasOptional(p => p.Persona).WithMany(r => r.Usuarios).HasForeignKey(p => p.PersonaId);

        }
    }
}
