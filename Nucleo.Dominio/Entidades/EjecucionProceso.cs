using System;
using Framework;

namespace Nucleo.Dominio.Entidades
{
    public class EjecucionProceso : IEntity
    {
        public int Id { get; private set; }
        public DateTime FechaEjecucion { get; set; }
        public string CodigoProceso { get; set; }
        public int UltimaEjecucion { get; set; }
        public int Estado { get; set; }
        public int ?  UsuarioCreacion { get; set; }
        public String Parametros { get; set; }
        public String Observacion { get; set; }

    }
}