using System;

namespace Nucleo.Dominio.DTO
{
    [Serializable]
    public class PersonaDTO
    {
        public int PersonaTipoId { get; set; }
        public int Id { get; set; }
        public string Apellidos => PrimerApellido + " " + SegundoApellido;
        public string Nombres => PrimerNombre + " " + SegundoNombre;
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string Movil { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int TipoDocumento { get; set; }
        public int EstadoCivil { get; set; }
        public string TipoDocumentoNombre { get; set; }
        public string EstadoCivilNombre { get; set; }
        public string TiposPersona { get; set; }
        public string TiposPersonaNombre { get; set; }

    }
}
