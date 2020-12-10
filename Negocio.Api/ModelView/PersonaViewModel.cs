using Framework.Security;

namespace Negocio.Api.Models
{
    public class PersonaViewModel
    {
        public int Id { get; set; }

        public string Apellidos => PrimerApellido + " " + SegundoApellido;

        public string Nombres => PrimerNombre+" "+SegundoNombre;

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public int TipoDocumento { get; set; }

        public string Identificacion { get; set; }

        public string Telefono { get; set; }

        public string Movil { get; set; }

        public string Correo { get; set; }

        public string ConfirmarCorreo { get; set; }

        public string Cuenta { get; set; }

        public string Clave { get; set; }

        public string ConfirmarClave { get; set; }

        public int EstadoCivil { get; set; }

        public Estado Estado { get; set; }

        public int? PersonaId { get; set; }

    }
}