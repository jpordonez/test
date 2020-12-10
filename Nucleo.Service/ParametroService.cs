using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Cache;
using Framework.Exception;
using Framework.Repository;
using Nucleo.Dominio;
using Nucleo.Dominio.Entidades;
using Negocio.Dominio.Constantes;

namespace Nucleo.Service
{
    public class ParametroService : IParametroService
    {
         
       
        IRepository<ParametroSistema> _repository;
        IRepository<ParametroOpcion> _repositoryParametroOpcion;
        ICacheManager _cacheManager;
        IApplication _application;

        public ParametroService(IApplication application, 
                                IRepository<ParametroSistema> repository,
                                IRepository<ParametroOpcion> repositoryParametroOpcion,
                                ICacheManager cacheManager)
        {
            _application = application;
            _repository = repository;
            _repositoryParametroOpcion = repositoryParametroOpcion;
            _cacheManager = cacheManager;
        }


        /// <summary>
        /// Recuperar el valor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetValor<T>(string codigoParametro)
        {
                    var parametros = GetParametros();

                    var parametro = parametros.Where(c => c.Codigo == codigoParametro).SingleOrDefault();
                    string error = string.Empty;
                    if (parametro == null){
                         error = string.Format("El parametro con el codigo  [{0}] no existe",codigoParametro);
                        throw new GenericException(error, error);
                    }

                    var valor = parametro.Valor as object;

                    //Verificar si el tipo pasado es el tipo especificado del valor del parametro
                    //si no son iguales lanzar exception...
                    Type tipoObjeto = Type.GetType(typeof(T).FullName);


                    if (tipoObjeto.Equals(typeof(string))) {
                        if (parametro.Tipo != TipoParametro.Cadena) { 
                            error = string.Format("El tipo de valor configurado es [{0}], sin embargo se trata de obtener con otro tipo [{1}]",TipoParametro.Cadena.ToString(),tipoObjeto.Name);
                            throw new GenericException(error, error);
                        }
                        return (T)valor;
                    }

                    if (tipoObjeto.Equals(typeof(int))) {
                        if (parametro.Tipo != TipoParametro.Numero)
                        {
                            error = string.Format("El tipo de valor configurado es [{0}], sin embargo se trata de obtener con otro tipo [{1}]", TipoParametro.Numero.ToString(), tipoObjeto.Name);
                            throw new GenericException(error, error);
                        }
                        return (T)(object)Convert.ToInt32(valor);
                    }

                    if (tipoObjeto.Equals(typeof(bool)))
                    {
                        if (parametro.Tipo != TipoParametro.Booleano)
                        {
                            error = string.Format("El tipo de valor configurado es [{0}], sin embargo se trata de obtener con otro tipo [{1}]", TipoParametro.Booleano.ToString(), tipoObjeto.Name);
                            throw new GenericException(error, error);
                        }
                        return (T)(object)Convert.ToBoolean(valor);
                    }

                    if (tipoObjeto.Equals(typeof(DateTime)))
                    {
                        if (parametro.Tipo != TipoParametro.Fecha)
                        {
                            error = string.Format("El tipo de valor configurado es [{0}], sin embargo se trata de obtener con otro tipo [{1}]", TipoParametro.Fecha.ToString(), tipoObjeto.Name);
                            throw new GenericException(error, error);
                        }
                        return (T)(object)Convert.ToDateTime(valor);
                    }


                    if (parametro.Tipo != TipoParametro.Listado)
                    {
                        error = string.Format("El tipo de valor configurado  [{0}], no es soportado", TipoParametro.Listado);
                        throw new GenericException(error, error);
                    }
                   

                    error = string.Format("El  tipo de valor [{0}] no es soportado", tipoObjeto.Name);
                    throw new GenericException(error, error);
 
        }

        private IEnumerable<ParametroSistema> GetParametros()
        {
            //Cache
            var parametros = _cacheManager.GetData(ConstantesCache.CACHE_PARAMETROS_SISTEMA) as IEnumerable<ParametroSistema>;
            if (parametros == null)
            {
                //1. Recuperar todos los parametros
                var sistema = _application.GetCurrentSistema();
                parametros = _repository.GetListIncluding(par => par.SistemaId == sistema.Id,include => include.Opciones);

                _cacheManager.Add(ConstantesCache.CACHE_PARAMETROS_SISTEMA, parametros);
            }
            return parametros;
        }




        public IEnumerable<ParametroSistema> GetList()
        {
            var parametros = GetParametros();
            return parametros;
        }


        public ParametroSistema Get(int id)
        {

            return _repository.Get(id);

            //TODO: No utilizar cache, ya que si este parametro se utiliza para modificar, se cambia el objeto del cache tambien

            //var parametros = GetParametros();

            //var parametro = parametros.Where(c => c.Id == id).SingleOrDefault();
            //string error = string.Empty;
            //if (parametro == null)
            //{
            //    error = string.Format("El parametro con el identificador  [{0}] no existe", id);
            //    throw new GenericException(error, error);
            //}

            //return parametro;

        }

        /// <summary>
        /// Obtener un parametro
        /// </summary>
        /// <returns></returns>
        public ParametroSistema Get(string codigoParametro)
        {
            var parametros = GetParametros();
            var parametro = parametros.FirstOrDefault(p=>p.Codigo.Equals(codigoParametro));
            if (parametro==null)
            {
                throw new Exception("No existe el parametro con codigo: "+codigoParametro);
            }
            return parametro;
        }

        public ParametroSistema SaveOrUpdate(ParametroSistema parametro)
        {

            var parametroActualizado = _repository.SaveOrUpdate(parametro);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_PARAMETROS_SISTEMA);

            return parametroActualizado;

        }

        public void Eliminar(int id)
        {
            var entidad = Get(id);
            _repository.Delete(entidad);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_CATALOGOS_SISTEMA);

        }

        public void EliminarOpciones(IList<ParametroOpcion> listEntity)
        {
            _repositoryParametroOpcion.Delete(listEntity);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_CATALOGOS_SISTEMA);
            
        }

}
}
