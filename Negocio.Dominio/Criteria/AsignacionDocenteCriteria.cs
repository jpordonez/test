using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class AsignacionDocenteCriteria
    {        
        public int? DocenteId { get; set; }
        public int NumeroPagina { get; set; }
    }
}