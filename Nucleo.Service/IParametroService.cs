using System.Collections.Generic;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio para parametros del Sistema
    /// </summary>
    public interface IParametroService
    {
        /// <summary>
        /// Obtener el valor del parametro 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codigoParametro"></param>
        /// <returns></returns>
        T GetValor<T>(string codigoParametro);

        /// <summary>
        /// Obtener listado de Parametros
        /// </summary>
        /// <returns></returns>
        IEnumerable<ParametroSistema> GetList();

        /// <summary>
        /// Obtener un parametro
        /// </summary>
        /// <param name="id">identificador del parametro</param>
        /// <returns></returns>
        ParametroSistema Get(int id);

        /// <summary>
        /// Obtener un parametro
        /// </summary>
        /// <param name="id">codigo del parametro</param>
        /// <returns></returns>
        ParametroSistema Get(string codigoParametro);

        /// <summary>
        /// Guardar o Actualiza un paraemtro 
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        ParametroSistema SaveOrUpdate(ParametroSistema parametro);

        void Eliminar(int id);

        void EliminarOpciones(IList<ParametroOpcion> listEntity);

    }
}
