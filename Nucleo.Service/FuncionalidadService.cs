using System.Collections;
using System.Collections.Generic;
using Framework.Cache;
using Framework.Repository;
using Framework.Security;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Negocio.Dominio.Constantes;

namespace Nucleo.Service
{
    public class FuncionalidadService : IFuncionalidadService
    {
        
       
        IRepository<Funcionalidad> _repository;
        IRepository<Accion> _repositoryAccion;
        ICacheManager _cacheManager;
        IApplication _application;

        public FuncionalidadService(IApplication application, 
                                    IRepository<Funcionalidad> repository,
                                    IRepository<Accion> repositoryAccion,
                                    ICacheManager cacheManager)
        {
            _application = application;
            _repository = repository;
            _repositoryAccion = repositoryAccion;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Obtener listado de funcionalidades del Sistema
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Funcionalidad> GetFuncionalidades()
        {
            var funcionalidades = _cacheManager.GetData(ConstantesCache.CACHE_FUNCIONALIDADES_SISTEMA) as IEnumerable<Funcionalidad>;
            if (funcionalidades == null)
            {
                //1. Recuperar las funcionalidaes
                var sistema = _application.GetCurrentSistema();
                funcionalidades = _repository.GetListIncluding(par => par.SistemaId == sistema.Id, incluir => incluir.Acciones);

                //TODO: JSA, Revisar si es mas conveniente establecer con una variable estatica a nivel de la aplicacion, y no utilizar el servicio de cache 
                //en ambos casos se tiene una copia del listado de todas funcionalidades del sistema.
                _cacheManager.Add(ConstantesCache.CACHE_FUNCIONALIDADES_SISTEMA, funcionalidades);
            }

            return funcionalidades;

        }

        /// <summary>
        /// Guardado de funcionalidad
        /// </summary>
        /// <returns></returns>
        public Funcionalidad SaveOrUpdate(Funcionalidad funcionalidad)
        {

            var funcionalidadActualizada = _repository.SaveOrUpdate(funcionalidad);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_FUNCIONALIDADES_SISTEMA);

            return funcionalidadActualizada;

        }

        /// <summary>
        /// Obtener funcionalidad
        /// </summary>
        /// <returns></returns>
        public Funcionalidad Get(int id)
        {
            return _repository.Get(id);
        }

        public void Eliminar(int id)
        {
            var entidad = Get(id);
            _repository.Delete(entidad);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_FUNCIONALIDADES_SISTEMA);

        }

        public void EliminarAcciones(IList<Accion> listEntity)
        {
            _repositoryAccion.Delete(listEntity);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_FUNCIONALIDADES_SISTEMA);

        }

        /// <summary>
        /// Obtener estados de funcionalidad
        /// </summary>
        /// <returns></returns>
        public IList GetEstados()
        {
            var estadoActivo = new { value = Estado.Activo, label = "Activo" };
            var estadoInactivo = new { value = Estado.Inactivo, label = "Inactivo" };

            var estados = new[] { estadoActivo, estadoInactivo };
            return estados;
        }

    }
}
