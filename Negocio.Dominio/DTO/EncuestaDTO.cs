using System;

namespace Negocio.Dominio.DTO
{
    public class EncuestaDTO
    {

        public int Id { get; set; }
        public string Codigo { get; set; }        
        public string Descripcion { get; set; }
        public string Funcion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
