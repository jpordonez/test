using System;

namespace Nucleo.Dominio.Criterias
{
    [Serializable]
    public class MenuCriteria
    {
        public string Nombre { get; set; }
        public int NumeroPagina { get; set; }
    }
}
