using System.Collections.Generic;

namespace Framework
{
    /// <summary>
    /// Clase para almacenar una lista paginada
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedListMetaData<T>
    {
        /// <summary>
        /// Listado de items paginados
        /// </summary>
        IList<T> Data { get; set; }

        /// <summary>
        /// Total de la lista, que se esta paginando
        /// </summary>
        int TotalRegistros { get; set; }

        /// <summary>
        /// Total de paginas para el query ejecutado
        /// </summary>
        int TotalPaginas { get; set; }

    }
}
