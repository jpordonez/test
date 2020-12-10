using System;

namespace Nucleo.Dominio.Criteria
{
    [Serializable]
    public class ParametroCriteria
    {
        public string Nombre { get; set; }
        public int NumeroPagina { get; set; }
    }
}
