using Framework.Security;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    public class EndUserAccessServiciosWeb: IEndUserAccess
    {
        public Usuario usuario;
        public Sesion sesion;
    }
}
