using System;

namespace Nucleo.Dominio.Criteria
{
    [Serializable]
    public class PersonaCriteria
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public int NumeroPagina { get; set; }

    }
}
