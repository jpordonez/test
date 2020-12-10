using System.ComponentModel.DataAnnotations;
using Framework;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Dominio.Models
{
    public partial class Institucion : IEntity
    {        

        [Key]
        public int Id { get; set; }

        public int? PersonaId { get; set; }

        [Required]
        [StringLength(80)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(13)]
        public string Ruc { get; set; }

        public int InscritoId { get; set; }

        [StringLength(80)]
        public string LugarInscripcion { get; set; }

        [StringLength(10)]
        public string NumeroAcuerdoRegistro { get; set; }

        public virtual Persona Persona { get; set; }

    }
}
