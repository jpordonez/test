using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class ProgramaCriteria
    {
        public string Nombre { get; set; }
        public string ModuloNombre { get; set; }
        public int? UniversidadId { get; set; }
        public int? EstadoId { get; set; }
        public int NumeroPagina { get; set; }
    }
}