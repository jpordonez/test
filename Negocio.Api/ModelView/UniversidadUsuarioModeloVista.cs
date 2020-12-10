namespace Negocio.Api.Models
{

    public class UniversidadUsuarioModeloVista
    {
        public int Id { get; set; }
        public int UniversidadId { get; set; }
        public string UniversidadCodigo { get; set; }
        public string UniversidadNombre { get; set; }
        public PersonaViewModel Usuario { get; set; }
    }

}