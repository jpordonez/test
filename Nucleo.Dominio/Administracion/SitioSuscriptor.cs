namespace Nucleo.Dominio.Models
{
    using Framework;
    using System.ComponentModel.DataAnnotations;

    public partial class SitioSuscriptor: IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }
    }
}
