using Framework.Cache;
using Framework.Repository;
using Negocio.Dominio.Constantes;
using Nucleo.Dominio;
using Nucleo.Dominio.Menus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio para la gestion de catalogos 
    /// </summary>
    public class MenuService : IMenuService
    {


        IRepository<Menu> _repository;
        IRepository<MenuItem> _repositoryItem;
        ICacheManager _cacheManager;
        IApplication _application;

        public MenuService( IApplication application, 
                            IRepository<Menu> repository,
                            IRepository<MenuItem> repositoryItem, 
                            ICacheManager cacheManager)
        {
            _application = application;
            _repository = repository;
            _repositoryItem = repositoryItem;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Obtener un Menu
        /// </summary>
        /// <param name="id">identificador del menu</param>
        /// <returns></returns>
        public Menu Get(int id) {

            return _repository.Get(id);

        }

        /// <summary>
        /// Obtener un MenuItem
        /// </summary>
        /// <param name="codigoItem">identificador del menu</param>
        /// <returns></returns>
        public MenuItem GetItem(string codigoItem) {
            var menuItem = _repositoryItem.GetQuery(mi => mi.Codigo.Equals(codigoItem)).FirstOrDefault();

            if (menuItem == null)
            {
                var error = string.Format("El MenuItem con el codigo [{0}] no existe.", codigoItem);
                throw new Exception(error);
            }

            return menuItem;
        }

        /// <summary>
        /// Obtener listado de Menu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Menu> GetList()
        {
            var menus = GetListMenus();

            return menus;
        }

        /// <summary>
        /// Guardar o Actualiza un menu 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public Menu Guardar(Menu menu)
        {

            var menuActualizado = _repository.SaveOrUpdate(menu);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_MENUS_SISTEMA);

            return menuActualizado;

        }

        /// <summary>
        /// Eliminar un menu
        /// </summary>
        /// <param name="id"></param>
        public void Eliminar(int id)
        {

            Menu entidad = Get(id);

            _repository.Delete(entidad);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_MENUS_SISTEMA);


        }

        /// <summary>
        /// Eliminar un MenuItem
        /// </summary>
        /// <param name="listEntity"></param>
        public void EliminarItems(IList<MenuItem> listEntity)
        {
            _repositoryItem.Delete(listEntity);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_MENUS_SISTEMA);

        }

        private IEnumerable<Menu> GetListMenus()
        {
            //Cache
            var menus = _cacheManager.GetData(ConstantesCache.CACHE_MENUS_SISTEMA) as IEnumerable<Menu>;
            if (menus == null)
            {
                //1. Recuperar todos los parametros
                var sistema = _application.GetCurrentSistema();
                menus = _repository.GetListIncluding(par => par.SistemaId == sistema.Id, c => c.Items);

                _cacheManager.Add(ConstantesCache.CACHE_MENUS_SISTEMA, menus);
            }
            return menus;
        }

    }
}
