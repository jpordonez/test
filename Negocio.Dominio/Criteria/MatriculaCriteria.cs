using System;

namespace Negocio.Dominio.Criteria
{
    [Serializable]
    public class MatriculaCriteria
    {        
        public int? EstudianteId { get; set; }
        public int NumeroPagina { get; set; }
    }
}