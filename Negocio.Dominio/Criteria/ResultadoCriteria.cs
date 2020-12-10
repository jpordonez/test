using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class ResultadoCriteria
    {
        public int? DocenteId { get; set; }
        public string EstadoCoe { get; set; }        
        public int NumeroPagina { get; set; }
    }
}