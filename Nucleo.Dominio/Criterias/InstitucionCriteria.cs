using System;

namespace Nucleo.Dominio.Criteria
{
    [Serializable]
    public class InstitucionCriteria
    {
        public string Nombres { get; set; }
        public string Ruc { get; set; }
        public int NumeroPagina { get; set; }
    }
}
