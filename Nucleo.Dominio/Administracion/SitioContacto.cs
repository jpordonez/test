namespace Nucleo.Dominio.Models
{
    using Framework;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SitioContacto: IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(30)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(80)]
        public string Farmacia { get; set; }

        [Column(TypeName = "text")]
        public string Mensaje { get; set; }
    }
}
