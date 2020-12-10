using System.Collections.Generic;
using System.Linq;
using Framework.Cache;
using Framework.Exception;
using Framework.Repository;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using System;
using Negocio.Dominio.Constantes;
using System.Data.Entity;
using Framework.EntityFramewok;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio para la gestion de catalogos 
    /// </summary>
    public class CatalogoService : ICatalogoService
    {

        private readonly IRepository<Catalogo> _repository;
        private readonly IRepository<ItemCatalogo> _repositoryItem;
        private readonly ICacheManager _cacheManager;
        private readonly IApplication _application;
        private readonly DbContext _context;

        public CatalogoService(IApplication application,
            ICacheManager cacheManager,
            DbContext context)
        {
            _application = application;
            _cacheManager = cacheManager;
            _context = context;
            _repository = new EntityFrameworkRepository<Catalogo>(context);
            _repositoryItem = new EntityFrameworkRepository<ItemCatalogo>(context);
        }



        public IEnumerable<Catalogo> GetList() {
            var catalogos = GetListCatalogos();

            return catalogos;
        }


        public Catalogo Get(int id) {

            return _repository.Get(id);

            //TODO: No utilizar cache, ya que si este catalogo se utiliza para modificar, se cambia el objeto del cache tambien


            //var catalogos = GetListCatalogos();

            //var catalogo = catalogos.Where(c => c.Id == id).SingleOrDefault();
            //string error = string.Empty;
            //if (catalogo == null)
            //{
            //    error = string.Format("El catalogo con el identificador  [{0}] no existe", id);
            //    throw new GenericException(error, error);
            //}

            //return catalogo;

        }

        /// <summary>
        /// Obtener un ItemCatalogo
        /// </summary>
        /// <param name="id">identificador del item</param>
        /// <returns></returns>
        public ItemCatalogo GetItem(int id)
        {
            return _repositoryItem.Get(id);
        }

        public void Eliminar(int id)
        {

            Catalogo entidad = Get(id);

            _repository.Delete(entidad);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_CATALOGOS_SISTEMA);


        }


        public Catalogo Guardar(Catalogo catalogo, IList<ItemCatalogo> itemsEliminados) {                

            //JOR: Todos los repositorios del proceso atomico deben crearse utilizando el mismo _context
            var transaccion = _context.Database.BeginTransaction();
            try
            {
                catalogo = _repository.SaveOrUpdate(catalogo);

                _repositoryItem.Delete(itemsEliminados);

                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                transaccion.Dispose();
            }

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_CATALOGOS_SISTEMA);

            return catalogo;

        }



        /// <summary>
        /// Obtener el listado de items de un catalogo
        /// </summary>
        /// <param name="codigoCatalogo"></param>
        /// <returns></returns>
        public ICollection<ItemCatalogo> GetItemsCatalogo(string codigoCatalogo)
        {
            var catalogos = GetListCatalogos();

            //Verificar existencia
            var catalogo = catalogos.Where(c => c.Codigo == codigoCatalogo).SingleOrDefault();
            string error = string.Empty;
            if (catalogo == null)
            {
                error = string.Format("El catalogo con el codigo  [{0}] no existe", codigoCatalogo);
                throw new GenericException(error, error);
            }

            //Recuperar listado solo items con estado activo
            return catalogo.Items.Where(i=>i.Estado).ToList();
        }

        public ItemCatalogo GetItem(string codigoItem)
        {
            var item = _repositoryItem.GetQuery(i => i.Codigo.Equals(codigoItem)).FirstOrDefault();

            string error = string.Empty;

            if (item == null)
            {
                error = string.Format("El item con el codigo  [{0}] no existe.", codigoItem);
                throw new Exception(error);
            }

            //Recuperar listado 
            return item;
        }

        /// <summary>
        /// Obtener listado de items de un item padre, por medio del codigo del item
        /// </summary>
        /// <param name="codigoItem"></param>
        /// <returns></returns>
        public ICollection<ItemCatalogo> GetItemsHijos(string codigoItem)
        {
            var itemsHijos = _repositoryItem.GetListIncluding(i => i.CodigoCatalogo == codigoItem);

            //Recuperar listado 
            return itemsHijos as ICollection<ItemCatalogo>;

        }

        private IEnumerable<Catalogo> GetListCatalogos()
        {
            //Cache
            var catalogos = _cacheManager.GetData(ConstantesCache.CACHE_CATALOGOS_SISTEMA) as IEnumerable<Catalogo>;
            if (catalogos == null)
            {
                //1. Recuperar todos los parametros
                var sistema = _application.GetCurrentSistema();
                catalogos = _repository.GetListIncluding(par => par.SistemaId == sistema.Id, c => c.Items);

                _cacheManager.Add(ConstantesCache.CACHE_CATALOGOS_SISTEMA, catalogos);
            }
            return catalogos;
        }

    }
}
