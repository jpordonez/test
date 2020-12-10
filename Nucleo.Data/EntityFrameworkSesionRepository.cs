using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Framework;
using Framework.EntityFramewok;
using Framework.MVC;
using Framework.Security;
using Framework.Util;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Data.EF
{
    public class EntityFrameworkSesionRepository : EntityFrameworkRepository<Sesion>, ISesionRepository<Sesion>
    {


        public EntityFrameworkSesionRepository(DbContext context, IIdentityUser identityUser, IManagerDateTime managerDateTime)
            : base(context)
        {
            
        }

         public IPagedListMetaData<Sesion> Buscar(SesionCriteria criteria, int Skip, int Take)
        {
            Guard.AgainstLessThanValue(Skip, "Skip", 0);
            Guard.AgainstLessThanValue(Take, "Take", 0);


            var query =  GetSet().AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Cuenta))
                query = query.Where(p => p.Cuenta.ToUpper().Trim().StartsWith(criteria.Cuenta.ToUpper().Trim()));

            if (criteria.Estado.HasValue) {
                query = query.Where(p => p.EstadoId == criteria.Estado.Value);

            }

            if (criteria.Fecha.HasValue)
            {
                query = query.Where(p => p.Inicio >= DbFunctions.TruncateTime(criteria.Fecha.Value) && p.Inicio <= DbFunctions.AddDays(criteria.Fecha.Value,1));

            }

            query = query.OrderByDescending(p => p.Inicio);

            var totalResultSetCount = query.Count();

            query = query.Skip(Skip).Take(Take);


            IEnumerable<Sesion> resultList;

            if (totalResultSetCount > 0)
                resultList = query.ToList();
            else
                resultList = new List<Sesion>();

            var result = new PagedListMetaData<Sesion>();
            result.TotalRegistros = totalResultSetCount;
            result.Data = resultList.ToList();


            return result;
        }
    }
}
