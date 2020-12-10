using System.Collections.Generic;
using Nucleo.Dominio.Entidades;

namespace Negocio.Api.Models
{
    public class ParametroModeloVista
    {
        public ParametroModeloVista()
        {
            Opciones = new List<ParametroOpcionModeloVista>();
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoParametro Tipo { get; set; }
        public string Valor { get; set; }
        public bool EsEditable { get; set; }
        public List<ParametroOpcionModeloVista> Opciones { get; set; } 
	        
    }
    public class ParametroOpcionModeloVista
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Valor { get; set; }

    }

}