using System.Collections.Generic;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Service
{
    public interface IRolService
    {
        /// <summary>
        /// Obtener listado de Roles
        /// </summary>
        /// <returns></returns>
        IEnumerable<Rol> GetList();

        /// <summary>
        /// Obtener Rol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Rol Get(int id);

        /// <summary>
        /// Obtener Rol
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Rol Get(string codigo);

        /// <summary>
        /// Actualiza los permisos de un rol. Crear Permisos, o eliminar permisos, segun el listado de identificadores de acciones enviados
        /// </summary>
        /// <param name="rol">Rol</param>
        /// <param name="listAccionId">Lista de acciones de funcionalidades que debe posee</param>
        /// <returns></returns>
        Rol UpdatePermissions(Rol rol, int[] listAccionId);

        /// <summary>
        /// Actualizacion de un rol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        Rol SaveOrUpdate(Rol rol);

        /// <summary>
        /// Eliminar un Rol
        /// </summary>
        /// <param name="id"></param>
        void Eliminar(int id);

        /// <summary>
        /// Eliminar permisos
        /// </summary>
        /// <param name="listEntity"></param>
        void EliminarPermisos(IList<Permiso> listEntity);

    }
}
