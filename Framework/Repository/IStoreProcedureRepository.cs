using System.Collections;
using System.Collections.Generic;

namespace Framework.Repository
{
    /// <summary>
    /// Interfaz de informacion de un usuario
    /// </summary>
    public interface IStoreProcedureRepository<T> where T : class
    {
        IList<T> SpConResultados(string comando, IEnumerable parametros, bool sinTimeout = false);

        IPagedListMetaData<T> SpConResultadosPaginado(string comando, IEnumerable parametros, int pagina);

        void SpConParametrosSalida(string comando, IEnumerable parametros);

        void SpConsola(string comando, IEnumerable parametros);

        string ObtenerValorSecuencia(string codigoSecuencia);

    }
}