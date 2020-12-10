using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class OfertaProgramaCriteria
    {        
        public int? PeriodoAcademicoId { get; set; }
        public int? CentroId { get; set; }
        public int? ModuloId { get; set; }
        public int? DocenteId { get; set; }
        public int NumeroPagina { get; set; }
    }
}