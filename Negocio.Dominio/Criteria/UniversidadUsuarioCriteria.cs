using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class UniversidadUsuarioCriteria
    {
        public int? UniversidadId { get; set; }
        public int? UsuarioId { get; set; }
        public int? EstadoId { get; set; }
        public int NumeroPagina { get; set; }
    }
}