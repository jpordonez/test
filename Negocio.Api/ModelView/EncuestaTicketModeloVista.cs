using System.Collections.Generic;

namespace Negocio.Api.Models
{

    public class TicketModeloVista
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public bool Reenviar { get; set; }
    }

    public class OfertaProgramaTicketModeloVista
    {
        public OfertaProgramaTicketModeloVista()
        {
            Tickets = new List<TicketModeloVista>();
        }
        public int Id { get; set; }        
        public List<TicketModeloVista> Tickets { get; set; }
    }

}