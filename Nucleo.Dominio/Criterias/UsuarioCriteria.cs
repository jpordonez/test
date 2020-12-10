using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nucleo.Dominio.Criterias
{
    [Serializable]
    public class UsuarioCriteria
    {
        public UsuarioCriteria()
        {
            FarmaciaIds = new List<int>();
        }
        public List<int> FarmaciaIds { get; set; }

        [DisplayName("Identificación: ")]
        public string Identificacion { get; set; }
        [DisplayName("Cuenta: ")]
        public string Cuenta { get; set; }

        public int? RolId { get; set; }

        public int NumeroPagina { get; set; }

    }
}
