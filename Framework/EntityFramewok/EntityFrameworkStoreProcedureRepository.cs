using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Framework.Exception;
using Framework.Logging;
using Framework.Repository;
using Framework.Service;
using Microsoft.Practices.ServiceLocation;
using Framework.MVC;

namespace Framework.EntityFramewok
{
    public class EntityFrameworkStoreProcedureRepository<T> : IStoreProcedureRepository<T> where T : class, new()
    {

        /// <summary>
        /// Variable paraa realizar Log
        /// </summary>
        private static readonly ILogger Log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(EntityFrameworkStoreProcedureRepository<>));

        protected DbContext _context;

        public EntityFrameworkStoreProcedureRepository(DbContext context)
        {
            _context = context;
        }


        public IList<T> SpConResultados(string comando, IEnumerable parametros, bool sinTimeout = false)
        {
            IEnumerable<SqlParameter> parametrosSqlServer = null;
            try
            {
                parametrosSqlServer = parametros.Cast<SqlParameter>();
            }
            catch (InvalidCastException e)
            {
                Log.Debug("No se puede realizar conversion de parametros para IEnumerable<SqlParameter>", e);
            }
            try
            {
                IList<T> resultado = new List<T>();

                //TODO: JSA, existe un inconveniente con cerrar el objeto Connection
                //al momento de llamar varias veces a este metodo, el primero funciona, el segundo
                //lanza error porque el objeto   _context.Database.Connection esta <<dispose>> con el uso de 
                //instruccion 
                // using (_context.Database.Connection)

                //Alternativa. Abrir y cerrar conecion al inicio y final del bloque
                //Revisar, si es necesario abrir y cerrar ya que el contexto "ciclo vida" es manejado por el contenedor de dependencias

                //using (_context.Database.Connection)
                //{
                _context.Database.Connection.Open();
                DbCommand cmd = _context.Database.Connection.CreateCommand();
                cmd.CommandText = comando;
                cmd.CommandType = CommandType.StoredProcedure;
                //Para el tiempo prolongado para procesos batch
                if (sinTimeout)
                {
                    cmd.CommandTimeout = 0;
                }
                foreach (var parametro in parametros)
                {
                    cmd.Parameters.Add(parametro);
                }
                var watch = Stopwatch.StartNew();
                using (var reader = cmd.ExecuteReader())
                {
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Log.Debug("Tiempo ejecucion sp (" + comando + "): " + elapsedMs + " ms");

                    watch = Stopwatch.StartNew();

                    //Opcion 1. Mapeo Manual
                    var res = reader.MapToList<T>();
                    resultado = res.Data;

                    //Opcion 2. Mapeo con AutoMapper
                    //if (reader.HasRows)
                    //{
                    //    CacheMapper<T>();
                    //    resultado = Mapper.Map<IDataReader, IList<T>>(reader);
                    //}

                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Log.Debug("Tiempo mapeo resultados para lista<T>: " + elapsedMs + " ms");
                }

                _context.Database.Connection.Close();
                if (parametrosSqlServer != null)
                {
                    var parametrosCadena = string.Join("|", parametrosSqlServer.Select(pss => pss.ParameterName + ":" + pss.Value));
                    var mensaje = "Correcto ejecucion sp " + comando + " => " + parametrosCadena;
                    Log.Debug(mensaje);
                }
                //}
                return resultado;
            }
            catch (System.Exception ex)
            {
                if (parametrosSqlServer != null)
                {
                    var parametrosCadena = string.Join("|", parametrosSqlServer.Select(pss => pss.ParameterName + ":" + pss.Value));
                    var mensaje = "Fallo ejecucion sp " + comando + " => " + parametrosCadena;
                    Log.Debug(mensaje, ex);
                    throw new ProcedimientoAlmacenadoExcepcion(mensaje, ex);
                }
                else
                {
                    throw ex;
                }

            }

        }

        public IPagedListMetaData<T> SpConResultadosPaginado(string comando, IEnumerable parametros, int pagina)
        {
            pagina = pagina < 1 ? 1 : pagina;
            IEnumerable<SqlParameter> parametrosSqlServer = null;
            try
            {
                parametrosSqlServer = parametros.Cast<SqlParameter>();
            }
            catch (InvalidCastException e)
            {
                Log.Debug("No se puede realizar conversion de parametros para IEnumerable<SqlParameter>", e);
            }
            try
            {

                IPagedListMetaData<T> resultado = new PagedListMetaData<T>();

                //TODO: JOR - Revisar la eficiencia de abrir y cerrar conexiones.
                var iMetaDataPaginacionServicio = ServiceLocator.Current.GetInstance<IMetaDataPaginacionServicio>();

                var connectionString = ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = comando;

                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.Add(parametro);
                    }

                    /* Fijar parametros paginacion*/
                    var pageNumber = new SqlParameter("@pageNumber", SqlDbType.Int)
                    {
                        Value = pagina
                    };
                    var pageSize = new SqlParameter("@pageSize", SqlDbType.Int)
                    {
                        Value = iMetaDataPaginacionServicio.getPageSize()
                    };

                    cmd.Parameters.Add(pageNumber);
                    cmd.Parameters.Add(pageSize);

                    conn.Open();
                    var watch = Stopwatch.StartNew();
                    using (var reader = cmd.ExecuteReader())
                    {
                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Log.Debug("Tiempo ejecucion sp (" + comando + "): " + elapsedMs + " ms");

                        watch = Stopwatch.StartNew();

                        //Opcion 1. Mapeo Manual
                        resultado = reader.MapToList<T>();

                        resultado.TotalPaginas = resultado.TotalRegistros / iMetaDataPaginacionServicio.getPageSize();

                        if (resultado.TotalRegistros % iMetaDataPaginacionServicio.getPageSize() != 0)
                        {
                            resultado.TotalPaginas++;
                        }

                        //Opcion 2. Mapeo con AutoMapper
                        //if (reader.HasRows)
                        //{
                        //    CacheMapper<T>();
                        //    resultado = Mapper.Map<IDataReader, IList<T>>(reader);
                        //}

                        watch.Stop();
                        elapsedMs = watch.ElapsedMilliseconds;
                        Log.Debug("Tiempo mapeo resultados para lista<T>: " + elapsedMs + " ms");
                    }
                }

                if (parametrosSqlServer != null)
                {
                    var parametrosCadena = string.Join("|", parametrosSqlServer.Select(pss => pss.ParameterName + ":" + pss.Value));
                    var mensaje = "Correcto ejecucion sp " + comando + " => " + parametrosCadena;
                    Log.Debug(mensaje);
                }
                //}
                return resultado;
            }
            catch (System.Exception ex)
            {
                if (parametrosSqlServer != null)
                {
                    var parametrosCadena = string.Join("|", parametrosSqlServer.Select(pss => pss.ParameterName + ":" + pss.Value));
                    var mensaje = "Fallo ejecucion sp " + comando + " => " + parametrosCadena;
                    Log.Debug(mensaje, ex);
                    throw new ProcedimientoAlmacenadoExcepcion(mensaje, ex);
                }
                else
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// Cache de configuraciones de mapeos
        /// </summary>
        private static ConcurrentDictionary<string, Type> cacheMapper = new ConcurrentDictionary<string, Type>();

        private void CacheMapper<TEntity>()
        {
            var typeName = typeof(TEntity).ToString();

            if (!(cacheMapper.ContainsKey(typeName))) // && useCache))
            {

                //Guardar configuracion del mapper
                AutoMapper.Mapper.Configuration.CreateMap<IDataReader, TEntity>();

                cacheMapper[typeName] = typeof(TEntity);
            }
        }

        public void SpConParametrosSalida(string comando, IEnumerable parametros)
        {
            var watch = Stopwatch.StartNew();

            _context.Database.Connection.Open();
            DbCommand cmd = _context.Database.Connection.CreateCommand();
            cmd.CommandText = comando;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddRange(parametros.Cast<object>().ToArray());


            cmd.ExecuteNonQuery();

            _context.Database.Connection.Close();

            //_context.Database.ExecuteSqlCommand(
            //        comando,
            //        parametros.Cast<object>().ToArray());

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Log.Debug("Tiempo ejecucion sp (" + comando + "): " + elapsedMs + " ms");
        }

        public void SpConsola(string comando, IEnumerable parametros)
        {
            var watch = Stopwatch.StartNew();
            _context.Database.Connection.Open();
            DbCommand cmd = _context.Database.Connection.CreateCommand();
            cmd.CommandText = comando;
            cmd.CommandType = CommandType.StoredProcedure;
            //Para el tiempo prolongado para procesos batch
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddRange(parametros.Cast<object>().ToArray());
            cmd.ExecuteNonQuery();
            _context.Database.Connection.Close();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Log.Debug("Tiempo ejecucion sp (" + comando + "): " + elapsedMs + " ms");
        }

        public string ObtenerValorSecuencia(string codigoSecuencia)
        {
            var parametros = new List<Object>();

            var codigo = new SqlParameter("@ec_codigo_secuencia", SqlDbType.VarChar)
            {
                Value = codigoSecuencia,
                Direction = ParameterDirection.Input
            };

            var valor = new SqlParameter("@sc_valor", SqlDbType.VarChar, 15)
            {
                Value = null,
                Direction = ParameterDirection.Output
            };

            parametros.Add(codigo);
            parametros.Add(valor);

            SpConParametrosSalida("pro_obt_codigo", parametros);

            return valor.Value.ToString();
        }

    }

    public static class DataReaderExtensions
    {

        /// <summary>
        /// Cache de propiedades
        /// </summary>
        private static ConcurrentDictionary<string, Dictionary<string, PropertyInfo>> cacheProperties = new ConcurrentDictionary<string, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// Obtener las propiedades del un tipo especifico
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<string, PropertyInfo> GetCacheProperties(Type type)
        {
            Dictionary<string, PropertyInfo> properties;
            var typeName = type.ToString();

            if (cacheProperties.ContainsKey(typeName)) // && useCache)
            {
                properties = cacheProperties[typeName];
            }
            else
            {
                var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                properties = props.ToDictionary(p => p.Name.ToUpper(), p => p);

                cacheProperties[typeName] = properties;
            }

            return properties;
        }


        public static IPagedListMetaData<T> MapToList<T>(this DbDataReader dr) where T : new()
        {
            int totalRegistros = 0;
            var entities = new List<T>();
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);
                var propDict = DataReaderExtensions.GetCacheProperties(typeof(T));
                bool esPrimeraFila = true;
                while (dr.Read())
                {
                    T newObject = new T();
                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (esPrimeraFila)
                        {
                            if (dr.GetName(index).ToUpper().Equals("totalRegistros".ToUpper()))
                            {
                                var val = dr.GetValue(index);
                                try
                                {
                                    totalRegistros = Convert.ToInt32(val);
                                }
                                catch (System.Exception e)
                                {
                                    throw new System.Exception("totalPaginas debe ser un valor entero", e);
                                }
                            }
                        }
                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = propDict[dr.GetName(index).ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                try
                                {
                                    info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                                }
                                catch (System.Exception e)
                                {
                                    throw new System.Exception("Tipos incompatibles para el campo: " + info.Name + ", revice que la clase y el valor devuelto por el sp sean compatibles", e);
                                }

                            }
                        }
                    }
                    entities.Add(newObject);
                    esPrimeraFila = false;
                }
            }
            var resultado = new PagedListMetaData<T> { Data = entities, TotalRegistros = totalRegistros };
            return resultado;
        }
    }

}
