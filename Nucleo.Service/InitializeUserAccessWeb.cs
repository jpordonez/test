using Framework.Security;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    public class InitializeUserAccessWeb : IInitializeUserAccess
    {
        public Usuario usuario;
        public Rol rol;
        public string ipAddress;
    }
}
