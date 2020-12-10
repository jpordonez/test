using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework.Logging;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Models;
using Nucleo.Dominio.Criteria;
using Framework;

namespace Nucleo.Service
{
    public class InstitucionService : IInstitucionService
    {

        private static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(PersonaService));
        private IRepository<Institucion> _repositoryInstitucion;

        public InstitucionService(IRepository<Institucion> repositoryInstitucion)
        {
            _repositoryInstitucion = repositoryInstitucion;
        }

        public Institucion Get(int id)
        {
            return _repositoryInstitucion.Get(id);
        }

        public IPagedListMetaData<InstitucionDTO> GetList(InstitucionCriteria criteria)
        {
            var _manejadorSP = ServiceLocator.Current.GetInstance<IStoreProcedureRepository<InstitucionDTO>>();

            var parametros = new List<Object>();

            var nombres = new SqlParameter("@nombres", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(criteria.Nombres) ? null : criteria.Nombres
            };

            var apellidos = new SqlParameter("@ruc", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(criteria.Ruc) ? null : criteria.Ruc
            };

            parametros.Add(nombres);
            parametros.Add(apellidos);

            var resultadoPaginado = _manejadorSP.SpConResultadosPaginado("pro_obt_instituciones", parametros, criteria.NumeroPagina);

            return resultadoPaginado;
        }

        public Institucion Guardar(Institucion institucion)
        {
            return _repositoryInstitucion.SaveOrUpdate(institucion);
        }

        public void Eliminar(int id)
        {
            Institucion entidad = Get(id);
            _repositoryInstitucion.Delete(entidad);
        }
    }
}
