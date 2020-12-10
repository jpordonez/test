using System.Collections.Generic;
using Nucleo.Dominio.Menus;

namespace Nucleo.Dominio
{
    public interface IMenuRespository
    {

        /// <summary>
        /// Obtener un listado de items de menus de un menu especifico, asociado a un ROL. (Mecanismo de seguridad)
        /// </summary>
        /// <param name="codigoMenu"></param>
        /// <param name="rolId"></param>
        /// <returns></returns>
        IList<MenuItem> GetMenuItemAssociatedRole(string codigoMenu,int rolId);

    }
}
