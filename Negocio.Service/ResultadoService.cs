using Framework.EntityFramewok;
using Framework.Logging;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using System.Data.Entity;
using Negocio.Dominio.Models;
using System;
using Nucleo.Dominio.DTO;
using Negocio.Dominio.Criteria;
using System.Linq;
using Framework;
using Negocio.Dominio.Codigos;
using System.Linq.Expressions;
using System.Collections.Generic;
using Negocio.Dominio.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Negocio.Service
{
    public class ResultadoService : IResultadoService
    {

        private readonly IApplication _application;
        private static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(MatriculaService));
        private readonly IRepository<Resultado> _repositoryResultado;
        private readonly DbContext _context;

        public ResultadoService(IApplication application,
            DbContext context)
        {
            _application = application;
            _context = context;
            _repositoryResultado = new EntityFrameworkRepository<Resultado>(context);
        }

        public Resultado Get(int id)
        {
            return _repositoryResultado.Get(id);
        }

        public IPagedListMetaData<ResultadoDTO> GetList(ResultadoCriteria criteria)
        {
            var _manejadorSP = ServiceLocator.Current.GetInstance<IStoreProcedureRepository<ResultadoDTO>>();

            var parametros = new List<Object>();

            var nombre = new SqlParameter("@docente_id", SqlDbType.Int)
            {
                Value = criteria.DocenteId
            };

            parametros.Add(nombre);

            var resultadoPaginado = _manejadorSP.SpConResultadosPaginado("pro_obt_resultados", parametros, criteria.NumeroPagina);

            if (!string.IsNullOrEmpty(criteria.EstadoCoe))
            {
                resultadoPaginado.Data = resultadoPaginado.Data.Where(r => r.Estado.Equals(criteria.EstadoCoe)).ToList();
            }

            return resultadoPaginado;
        }

        public Resultado Guardar(Resultado entidad)
        {
            return _repositoryResultado.SaveOrUpdate(entidad);
        }

        public void Eliminar(int id)
        {
            var entidad = Get(id);
            _repositoryResultado.Delete(entidad);
        }

    }
}