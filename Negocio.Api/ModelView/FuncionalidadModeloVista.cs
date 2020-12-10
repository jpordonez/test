using System.Collections.Generic;
using Framework.Security;

namespace Negocio.Api.Models
{
    public class FuncionalidadModeloVista
    {
        public FuncionalidadModeloVista()
        {
            Acciones = new List<AccionModeloVista>();
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Controlador { get; set; }
        public string Descripcion { get; set; }
        public Estado EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public List<AccionModeloVista> Acciones { get; set; }

    }
    public class AccionModeloVista
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

}