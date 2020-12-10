using Nucleo.Dominio.Menus;
using System.Collections.Generic;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio de Catalogos
    /// </summary>
    public interface IMenuService
    {

        /// <summary>
        /// Obtener un Menu
        /// </summary>
        /// <param name="id">identificador del menu</param>
        /// <returns></returns>
        Menu Get(int id);

        /// <summary>
        /// Obtener un MenuItem
        /// </summary>
        /// <param name="codigoItem">identificador del menu</param>
        /// <returns></returns>
        MenuItem GetItem(string codigoItem);

        /// <summary>
        /// Obtener listado de Menu
        /// </summary>
        /// <returns></returns>
        IEnumerable<Menu> GetList();

        /// <summary>
        /// Guardar o Actualiza un menu 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        Menu Guardar(Menu menu);

        /// <summary>
        /// Eliminar un menu
        /// </summary>
        /// <param name="id"></param>
        void Eliminar(int id);

        /// <summary>
        /// Eliminar MenuItems
        /// </summary>
        /// <param name="listEntity"></param>
        void EliminarItems(IList<MenuItem> listEntity);

    }
}
