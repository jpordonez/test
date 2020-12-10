using Framework.Security;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    public class InitializeUserAccessServiciosWeb: IInitializeUserAccess
    {
        public Usuario usuario;
        public Rol rol;
        public string ipAddress;
    }
}
