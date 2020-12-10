namespace Negocio.Dominio.Models
{
    using Framework;
    using Nucleo.Dominio.Entidades;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Matricula : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matricula()
        {
            this.Resultado = new HashSet<Resultado>();
        }

        [Key]
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int ComponenteEducativoId { get; set; }
        public System.DateTime Fecha { get; set; }

        public virtual ComponenteEducativo ComponenteEducativo { get; set; }
        public virtual Persona Estudiante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resultado> Resultado { get; set; }
    }
}
