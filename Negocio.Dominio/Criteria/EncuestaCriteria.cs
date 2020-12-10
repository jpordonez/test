using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class EncuestaCriteria
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int NumeroPagina { get; set; }
    }
}
