using System;

namespace Nucleo.Dominio.DTO
{

    [Serializable]
    public class InstitucionDTO
    {
        public int Id { get; set; }
        public int RepresentanteId { get; set; }
        public string RepresentanteNombres { get; set; }
        public string RepresentanteApellidos { get; set; }
        public string RepresentanteIdentificacion { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public int InscritoId { get; set; }
        public string IncritoEnNombre { get; set; }
        public string LugarInscripcion { get; set; }
        public string NumeroAcuerdo { get; set; }

    }

}
