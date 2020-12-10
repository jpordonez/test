using System;

namespace Nucleo.Dominio.Criteria
{
    [Serializable]
    public class CatalogoCriteria
    {
        public string Nombre { get; set; }
        public int NumeroPagina { get; set; }
    }
}
