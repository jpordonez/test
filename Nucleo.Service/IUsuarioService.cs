using System.Collections;
using System.Collections.Generic;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Seguridad;
using Framework;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio de Usuarios
    /// </summary>
    public interface IUsuarioService
    {

        Usuario Get(int id);
        Permiso GetPermiso(int id);
        IPagedListMetaData<UsuarioDTO> GetList(UsuarioCriteria criteria);
        Usuario Guardar(Usuario catalogo);
        void Eliminar(int id);
        void EliminarPermiso(int id);
        IList GetEstadosUsuario();
        IEnumerable<Rol> GetRolesSistema();
        bool ExisteUsuario(string cuenta);

    }
}
