using System;
using Framework.Security;

namespace Nucleo.Dominio.DTO
{
    [Serializable]
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Clave { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string EstadoNombre { get { return Estado == Estado.Activo ? "Activo" : "Inactivo"; } }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public Estado Estado { get; set; }
        public int? PersonaId { get; set; }
        public string RolIds { get; set; }
        public string RolNombres { get; set; }

    }
}
