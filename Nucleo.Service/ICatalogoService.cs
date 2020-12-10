using System.Collections.Generic;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio de Catalogos
    /// </summary>
    public interface ICatalogoService
    {

        /// <summary>
        /// Obtener un catalogo
        /// </summary>
        /// <param name="id">identificador del catalogo</param>
        /// <returns></returns>
        Catalogo Get(int id);

        /// <summary>
        /// Obtener un ItemCatalogo
        /// </summary>
        /// <param name="id">identificador del item</param>
        /// <returns></returns>
        ItemCatalogo GetItem(int id);

        /// <summary>
        /// Obtener listado de items de catalogos de un catalogo, por medio del codigo del catalogo
        /// </summary>
        /// <param name="codigoCatalogo"></param>
        /// <returns></returns>
        ICollection<ItemCatalogo> GetItemsCatalogo(string codigoCatalogo);

        ItemCatalogo GetItem(string codigoItem);

        /// <summary>
        /// Obtener listado de items de un item padre, por medio del codigo del item
        /// </summary>
        /// <param name="codigoItem"></param>
        /// <returns></returns>
        ICollection<ItemCatalogo> GetItemsHijos(string codigoItem);

        /// <summary>
        /// Obtener listado de Catalogos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Catalogo> GetList();

        /// <summary>
        /// Guardar o Actualiza un catalogo 
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        Catalogo Guardar(Catalogo catalogo, IList<ItemCatalogo> itemsEliminados);

        /// <summary>
        /// Eliminar un catalogo
        /// </summary>
        /// <param name="id"></param>

        void Eliminar(int id);


    }
}
