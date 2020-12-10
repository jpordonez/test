using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Models;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Dominio.Entidades
{
    public partial class Persona : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Instituciones = new HashSet<Institucion>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string PrimerNombre { get; set; }

        [StringLength(80)]
        public string SegundoNombre { get; set; }

        [Required]
        [StringLength(80)]
        public string PrimerApellido { get; set; }

        [StringLength(80)]
        public string SegundoApellido { get; set; }

        public int TipoDocumento { get; set; }

        [Required]
        [StringLength(20)]
        public string Identificacion { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(10)]
        public string Movil { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        public int EstadoCivil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Institucion> Instituciones { get; set; }

        public override string ToString()
        {
            return PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido;
        }

    }
}
