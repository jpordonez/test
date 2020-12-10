using System.Collections;
using System.Collections.Generic;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicios para la gestion de funcionalidades
    /// </summary>
    public interface IFuncionalidadService
    {
        /// <summary>
        /// Obtener listado de funcionalidades
        /// </summary>
        /// <returns></returns>
        IEnumerable<Funcionalidad> GetFuncionalidades();

        /// <summary>
        /// Guardado de funcionalidad
        /// </summary>
        /// <returns></returns>
        Funcionalidad SaveOrUpdate(Funcionalidad funcionalidad);

        /// <summary>
        /// Obtener funcionalidad
        /// </summary>
        /// <returns></returns>
        Funcionalidad Get(int id);

        void Eliminar(int id);

        void EliminarAcciones(IList<Accion> listEntity);

        /// <summary>
        /// Obtener estados de funcionalidad
        /// </summary>
        /// <returns></returns>
        IList GetEstados();

    }
}
