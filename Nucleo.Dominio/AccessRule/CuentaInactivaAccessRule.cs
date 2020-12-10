using Framework.Security;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Dominio.AccessRule
{
    /// <summary>
    /// Verificar si la cuenta del usuario se encuentra Inactiva
    /// </summary>
    public class CuentaInactivaAccessRule : IAccessRule
    {
        IUsuarioRepository<Usuario> _repository;

        public CuentaInactivaAccessRule(IUsuarioRepository<Usuario> repository) 
        {
            _repository = repository; 
        }
 
        public string Name { get; set; }
        public int Priority { get; set; }

        public void CheckRule(string username)
        {
            var user = _repository.Get(username);
 
            //if (user.EsBloqueado)
            //    throw new CuentaUsuarioInactivaAccessException();
        }
 
    }
}
