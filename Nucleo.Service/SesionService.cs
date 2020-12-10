using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Seguridad;
using Framework;

namespace Nucleo.Service
{
    public class SesionService : ISesionService
    {
        IRepository<Sesion> _repository;
        IApplication _application;

        public SesionService(   IApplication application, 
                                IRepository<Sesion> repository)
        {
            _application = application;
            _repository = repository;
        }

        /// <summary>
        /// Obtener listado de Sesiones
        /// </summary>
        /// <returns></returns>
        public IPagedListMetaData<SesionDTO> GetList(SesionCriteria criteria){
            var _manejadorSP = ServiceLocator.Current.GetInstance<IStoreProcedureRepository<SesionDTO>>();

            var parametros = new List<Object>();

            var Cuenta = new SqlParameter("@cuenta", SqlDbType.VarChar)
            {
                Value = string.IsNullOrWhiteSpace(criteria.Cuenta) ? null : criteria.Cuenta
            };

            var Estado = new SqlParameter("@estado_id", SqlDbType.Int)
            {
                Value = criteria.Estado
            };

            DateTime? fechaDesde = null;
            if (!string.IsNullOrWhiteSpace(criteria.FechaDesde))
            {
                fechaDesde = DateTime.Parse(criteria.FechaDesde, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            var FechaDesde = new SqlParameter("@fecha_desde", SqlDbType.DateTime)
            {
                Value = fechaDesde
            };

            DateTime? fechaHasta = null;
            if (!string.IsNullOrWhiteSpace(criteria.FechaHasta))
            {
                fechaHasta = DateTime.Parse(criteria.FechaHasta, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            var FechaHasta = new SqlParameter("@fecha_hasta", SqlDbType.DateTime)
            {
                Value = fechaHasta
            };

            parametros.Add(Cuenta);
            parametros.Add(Estado);
            parametros.Add(FechaDesde);
            parametros.Add(FechaHasta);

            var resultadoPaginado = _manejadorSP.SpConResultadosPaginado("pro_obt_sesiones", parametros, criteria.NumeroPagina);

            return resultadoPaginado;
        }
        
    }
}
