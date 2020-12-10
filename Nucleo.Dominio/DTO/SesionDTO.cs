using System;
using Framework.Security;

namespace Nucleo.Dominio.DTO
{
    [Serializable]
    public class SesionDTO
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public EstadoSesion EstadoId { get; set; }
        public string Ip { get; set; }
        public int RolId { get; set; }
        public string Rol { get; set; }
    }
}
