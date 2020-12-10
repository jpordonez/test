using System;
using System.Collections.Generic;

namespace Framework.MVC
{
    /// <summary>
    /// Representa los metadatos para listas paginas. Guarda la información del total de items existentes en la lista, y a lista pagina (subset)
    /// </summary>
    [Serializable]
    public class PagedListMetaData<T> : IPagedListMetaData<T>
    {

        /// <summary>
        /// Listado de items paginados
        /// </summary>
        public IList<T> Data { get; set; }

        /// <summary>
        /// Total de items que existe en la lista sin paginacion
        /// </summary>
        public int TotalRegistros { get; set; }

        /// <summary>
        /// Total de paginas para el query ejecutado
        /// </summary>
        public int TotalPaginas { get; set; }

    }
}
