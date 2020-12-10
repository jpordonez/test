using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Framework;
using Framework.EntityFramewok;
using Framework.MVC;
using Framework.Security;
using Framework.Util;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Data.EF
{
    public class EntityFrameworkAuditoriaRepository : EntityFrameworkRepository<Auditoria>, IAuditoriaRepository<Auditoria>
    {
         
        public EntityFrameworkAuditoriaRepository(DbContext context, IIdentityUser identityUser, IManagerDateTime managerDateTime)
            : base(context)
        {
            
        }

        public IPagedListMetaData<Auditoria> Buscar(AuditoriaCriteria criteria, int Skip, int Take)
        {
            Guard.AgainstLessThanValue(Skip, "Skip", 0);
            Guard.AgainstLessThanValue(Take, "Take", 0);


            var query =  GetSet().AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Identificador))
                query = query.Where(p => p.Identificacion.ToUpper().Trim().StartsWith(criteria.Identificador.ToUpper().Trim()));

            if (!string.IsNullOrEmpty(criteria.Usuario))
                query = query.Where(p => p.Usuario.ToUpper().Trim().StartsWith(criteria.Usuario.ToUpper().Trim()));

            if (!string.IsNullOrEmpty(criteria.Funcionalidad))
                query = query.Where(p => p.Funcionalidad.ToUpper().Trim().StartsWith(criteria.Funcionalidad.ToUpper().Trim()));

            if (!string.IsNullOrEmpty(criteria.Accion))
                query = query.Where(p => p.Accion.ToUpper().Trim().StartsWith(criteria.Accion.ToUpper().Trim()));


            //Fecha
            if (criteria.FechaInicio.HasValue && criteria.FechaFinal.HasValue)
            {
                query = query.Where(p => p.Fecha >= DbFunctions.TruncateTime(criteria.FechaInicio.Value) && p.Fecha <= DbFunctions.AddDays(criteria.FechaFinal.Value,1));
            }
            else {
                if (criteria.FechaInicio.HasValue) {
                    query = query.Where(p => p.Fecha >= DbFunctions.TruncateTime(criteria.FechaInicio.Value));
                }
                else if (criteria.FechaFinal.HasValue)
                {
                    query = query.Where(p => p.Fecha <= DbFunctions.AddDays(criteria.FechaFinal.Value, 1));
                }
            }

            query = query.OrderByDescending(p => p.Fecha);

            var totalResultSetCount = query.Count();

            query = query.Skip(Skip).Take(Take);


            IEnumerable<Auditoria> resultList;

            if (totalResultSetCount > 0)
                resultList = query.ToList();
            else
                resultList = new List<Auditoria>();

            var result = new PagedListMetaData<Auditoria>();
            result.TotalRegistros = totalResultSetCount;
            result.Data = resultList.ToList();


            return result;
        }
    }
}
