using Framework.Security;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    /// <summary>
    /// Servio para accesos al sistema
    /// </summary>
    public interface IAccessService
    {
        /// <summary>
        /// Finaliza el acceso de un usuario al sistema
        /// </summary>
        void EndUserAccess(IEndUserAccess iEndUserAccess);

        /// <summary>
        ///  Inicia la acceso de un usuario al sistema
        /// </summary>
        void InitializeUserAccess(IInitializeUserAccess iInitializeUserAccess);
    }
}
