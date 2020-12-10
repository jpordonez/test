using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class UniversidadCriteria
    {
        public string Nombre { get; set; }
        public int? EstadoId { get; set; }
        public int NumeroPagina { get; set; }
    }
}