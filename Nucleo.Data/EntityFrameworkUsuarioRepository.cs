using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Framework;
using Framework.MVC;
using Framework.Repository;
using Framework.Security;
using Negocio.Dominio.Criteria;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Seguridad;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace Nucleo.Data.EF
{
    public class EntityFrameworkUsuarioRepository<TEntity> : IUsuarioRepository<TEntity>
      where TEntity : class, IUsuario
    {

        protected DbContext _context;
        protected IRepository<Usuario> _repository;

        public EntityFrameworkUsuarioRepository(DbContext context,
                                                IRepository<Usuario> repository)
        {
            _context = context;
            _repository = repository;
        }

        protected IDbSet<Usuario> GetSet()
        {
            return _context.Set<Usuario>();
        }



        public Usuario Get(int id)
        {
            var returnVal = GetSet().Find(id);
            return returnVal;
        }

        public Usuario Get(string cuenta)
        {
            return GetSet().AsQueryable().AsNoTracking().Where(c => c.Cuenta == cuenta).SingleOrDefault();
        }

        public Usuario GetByPersona(int id)
        {
            return GetSet().AsQueryable().Where(u => u.PersonaId == id).SingleOrDefault();
        }

        public Usuario SaveOrUpdate(Usuario usuario)
        {
            return _repository.SaveOrUpdate(usuario);
        }


        public void Dispose()
        {
            //TODO: JSA, REVISAR COMO SE REALIZAR LA LIBERACION DE CONTEXT, SI AL NIVEL DE CONTENEDOR DE INYECCION SE MANTENE SINGLETO
            //
            //_context.Dispose();
        }

        public IPagedListMetaData<IUsuario> Buscar(UsuarioCriteria criteria, int Skip, int Take)
        {
            Guard.AgainstLessThanValue(Skip, "Skip", 0);
            Guard.AgainstLessThanValue(Take, "Take", 0);


            var query = GetSet().AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Identificacion))
                query = query.Where(p => p.Identificacion.Trim().StartsWith(criteria.Identificacion.Trim()));

            if (!string.IsNullOrEmpty(criteria.Cuenta))
                query = query.Where(p => p.Cuenta.ToUpper().Trim().Contains(criteria.Cuenta.ToUpper().Trim()));


            query = query.OrderBy(p => p.Apellidos);

            var totalResultSetCount = query.Count();

            query = query.Skip(Skip).Take(Take);


            IEnumerable<IUsuario> resultList;

            if (totalResultSetCount > 0)
                resultList = query.ToList();
            else
                resultList = new List<Usuario>();

            var result = new PagedListMetaData<IUsuario>();
            result.TotalRegistros = totalResultSetCount;
            result.Data = resultList.ToList();


            return result;
        }

        public void Delete(Usuario entity)
        {
            var _entity = GetSet().Remove(entity);
            _context.SaveChanges();
        }

        public bool ExisteUsuario(string cuenta)
        {
            return GetSet().AsQueryable().Where(u => u.Cuenta.Equals(cuenta)).Any();
        }

    }
}
