using System;

namespace Nucleo.Dominio
{
    interface ISesion
    {
        string Cuenta { get; set; }
        int EstadoId { get; set; }
        DateTime Fin { get; set; }
        int Id { get; set; }
        DateTime Inicio { get; set; }
        int VersionRegistro { get; set; }
    }
}
