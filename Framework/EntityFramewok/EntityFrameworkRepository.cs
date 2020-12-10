using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Framework.Exception;
using Framework.Logging;
using Framework.MVC;
using Framework.Repository;
using Framework.Security;
using Framework.Util;
using Microsoft.Practices.ServiceLocation;
using Framework.Service;

namespace Framework.EntityFramewok
{
    /// <summary>
    /// Reporitory con Entity Framework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
       where TEntity : class, IEntity
    {

        static readonly ILogger log =
     ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(EntityFrameworkRepository<TEntity>));

        private IManagerDateTime _managerDateTime;

        private IIdentityUser _identityUser;

        protected DbContext _context;
        //{
        // get
        // {
        //     return  ServiceLocator.Current.GetInstance<DbContext>();
        // }
        //}

        public EntityFrameworkRepository(DbContext context)
        {
            _context = context;
            _identityUser = ServiceLocator.Current.GetInstance<IIdentityUser>();
            _managerDateTime = ServiceLocator.Current.GetInstance<IManagerDateTime>();
        }

        protected IDbSet<TEntity> GetSet()
        {
            return GetSet<TEntity>();
        }

        private IDbSet<TSource> GetSet<TSource>() where TSource : class, IEntity
        {
            return _context.Set<TSource>();
        }



        public TEntity Get(int id)
        {
            var returnVal = GetSet().Find(id);
            return returnVal;
        }

        //public TEntity Get(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        //{

        //    var returnVal = GetSet().Find(id);
        //    return returnVal;
        //}



        public TEntity SaveOrUpdate(TEntity entity)
        {
            Guard.AgainstArgumentNull(entity, "entity");

            //New
            if (entity.Id == 0)
            {
                GetSet().Add(entity);
            }
            else
            {
                //   //We query local context first to see if it's there.
                //  if (!Database.Set<TEntity>().Local.Any(e => e.ID == myObject.ID))
                //    Database.MyObjects.Attach(myObject);
                //else
                //    myObject = Database.Set<MyObject>().Local.Single(e => e.ID ==  myObject.ID)

                //   var x =  GetSet().Local.Any(e => e.Id == entity.Id); //(); //..Local.Find(entity.Id);

                if (GetSet().Local.Any(e => e.Id == entity.Id))
                {

                    var attachedEntryX = GetSet().Local.Single(e => e.Id == entity.Id);

                    var attachedEntry = _context.Entry(attachedEntryX);

                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {


                    //_context.Entry(existing).CurrentValues.SetValues(updated);
                    GetSet().Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;

                }

            }

            //GetSet().Attach
            //GetSet().Add(entity);
            Save(); //entity);

            //_context.SaveChanges();
            return entity;

            //using (var ctx = _context)
            //{
            //    var _entity = ctx.Set<TEntity>().Add(entity);
            //    ctx.SaveChanges();
            //    return _entity;
            //}


            //if (updated == null)
            //    return null;

            //TObject existing = await _context.Set<TObject>().FindAsync(key);
            //if (existing != null)
            //{
            //    _context.Entry(existing).CurrentValues.SetValues(updated);
            //    await _context.SaveChangesAsync();
            //}
            //return existing;
        }

        public IList<TEntity> SaveOrUpdate(IList<TEntity> listEntity)
        {
            Guard.AgainstArgumentNull(listEntity, "listEntity");

            foreach (var entity in listEntity)
            {
                //New
                if (entity.Id == 0)
                {
                    GetSet().Add(entity);
                }
                else
                {
                    //   //We query local context first to see if it's there.
                    //  if (!Database.Set<TEntity>().Local.Any(e => e.ID == myObject.ID))
                    //    Database.MyObjects.Attach(myObject);
                    //else
                    //    myObject = Database.Set<MyObject>().Local.Single(e => e.ID ==  myObject.ID)

                    //   var x =  GetSet().Local.Any(e => e.Id == entity.Id); //(); //..Local.Find(entity.Id);

                    if (GetSet().Local.Any(e => e.Id == entity.Id))
                    {

                        var attachedEntryX = GetSet().Local.Single(e => e.Id == entity.Id);

                        var attachedEntry = _context.Entry(attachedEntryX);

                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                    else
                    {


                        //_context.Entry(existing).CurrentValues.SetValues(updated);
                        GetSet().Attach(entity);
                        _context.Entry(entity).State = EntityState.Modified;

                    }

                }
            }


            Save();


            return listEntity;

        }


        public void Delete(TEntity entity)
        {
            var _entity = GetSet().Remove(entity);
            _context.SaveChanges();
        }


        public void Delete(IList<TEntity> listEntity)
        {
            Guard.AgainstArgumentNull(listEntity, "listEntity");

            foreach (var entity in listEntity)
            {
                GetSet().Remove(entity);
            }

            _context.SaveChanges();
        }


        /// <summary>
        /// The number of objects written to the underlying database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private int Save() //TEntity entity)
        {

            try
            {

                foreach (var dbEntityEntry in _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
                {
                    ///TODO: JSA que pase si existe un error se debe reversar la version???
                    IVersionable entityVersionable = dbEntityEntry.Entity as IVersionable;
                    if (entityVersionable != null)
                    {
                        entityVersionable.VersionRegistro = entityVersionable.VersionRegistro + 1;
                    }


                    IAuditableEntity entityAuditable = dbEntityEntry.Entity as IAuditableEntity;
                    if (entityAuditable != null)
                    {


                        var identifidadUsuario = _identityUser.GetCurrentIdentity();

                        DateTime fechaHora = _managerDateTime.Get();

                        if (dbEntityEntry.State == EntityState.Added)
                        {
                            entityAuditable.UsuarioCreacionId = identifidadUsuario;
                            entityAuditable.FechaCreacion = fechaHora;
                            entityAuditable.UsuarioActualizacionId = null;
                            entityAuditable.FechaActualizacion = null;
                        }
                        else
                        {
                            _context.Entry<IAuditableEntity>(entityAuditable).Property(x => x.FechaCreacion).IsModified = false;
                            _context.Entry<IAuditableEntity>(entityAuditable).Property(x => x.UsuarioCreacionId).IsModified = false;
                            entityAuditable.UsuarioActualizacionId = identifidadUsuario;
                            entityAuditable.FechaActualizacion = fechaHora;
                        }

                    }

                }
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //TODO: JSA mensajar mensajes de DbEntityValidationException
                var errorMessages = (from eve in ex.EntityValidationErrors
                                     let entity = eve.Entry.Entity.GetType().Name
                                     from ev in eve.ValidationErrors
                                     select new
                                     {
                                         Entity = entity,
                                         PropertyName = ev.PropertyName,
                                         ErrorMessage = ev.ErrorMessage
                                     });

                var fullErrorMessage = string.Join("; ", errorMessages.Select(e => string.Format("[Entity: {0}, Property: {1}] {2}", e.Entity, e.PropertyName, e.ErrorMessage)));

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            catch (DbUpdateException ex)
            {
                SqlException se = null;
                System.Exception next = ex;

                while (next.InnerException != null)
                {
                    se = next.InnerException as SqlException;
                    next = next.InnerException;
                }

                if (se != null && (se.Number == 2601 || se.Number == 2627))
                {
                    // Do your SqlException processing here
                    throw new ClaveDuplicadaExcepcion(se.Message);
                }
                else
                {
                    // Do other exception processing here
                    throw ex;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public bool Exists(Expression<Func<TEntity, bool>> criteria)
        {
            return GetSet().Where(criteria).Count() > 0;
        }

        public void Dispose()
        {
            //TODO: JSA, REVISAR COMO SE REALIZAR LA LIBERACION DE CONTEXT, 
            //SI AL NIVEL DE CONTENEDOR DE INYECCION SE MANTENE SINGLETO
            //_context.Dispose();
            //log.InfoFormat("EntityFrameworkRepository Dispose {0}", DateTime.Now);
        }


        public IEnumerable<TEntity> GetList()
        {
            var returnVal = GetSet().AsEnumerable();
            return returnVal;
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> criteria)
        {
            return GetSet().Where(criteria).ToList();
        }

        public IPagedListMetaData<TEntity> GetList<TKey>(int pagina, Expression<Func<TEntity, bool>> criteria = null, Expression<Func<TEntity, TKey>> orden = null)
        {
            Guard.AgainstLessThanValue(pagina, "pagina", 1);

            var iMetaDataPaginacionServicio = ServiceLocator.Current.GetInstance<IMetaDataPaginacionServicio>();

            var tamanioPagina = iMetaDataPaginacionServicio.getPageSize();

            var inicio = (pagina - 1) * tamanioPagina;

            var result = GetList(inicio, tamanioPagina, criteria, orden);

            return result;
        }

        public IPagedListMetaData<TEntity> GetList<TKey>(int Skip, int Take, Expression<Func<TEntity, bool>> criteria = null, Expression<Func<TEntity, TKey>> orden = null)
        {

            Guard.AgainstLessThanValue(Skip, "Skip", 0);
            Guard.AgainstLessThanValue(Take, "Take", 0);


            var query = GetSet().AsQueryable();

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            if (orden != null)
            {
                query = query.OrderByDescending(orden);
            }

            var totalResultSetCount = query.Count();

            query = query.Skip(Skip).Take(Take);


            IEnumerable<TEntity> resultList;

            if (totalResultSetCount > 0)
                resultList = query.ToList();
            else
                resultList = new List<TEntity>();

            var result = new PagedListMetaData<TEntity>();
            result.TotalRegistros = totalResultSetCount;
            result.Data = resultList.ToList();


            return result;
        }

        public IEnumerable<TEntity> GetListIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetSet().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }


        public IEnumerable<TEntity> GetListIncluding(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includeProperties)
        {


            var query = GetSet().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            query = query.Where(criteria);

            return query.ToList();
        }

        public IQueryable<TSource> GetQuery<TSource>(Expression<Func<TSource, bool>> predicate = null) where TSource : class, IEntity
        {
            var query = GetSet<TSource>().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null)
        {
            return GetQuery<TEntity>(predicate);
        }
    }


    public class EntityFrameworkRepositoryNamed<TEntity> : EntityFrameworkRepository<TEntity>, IRepositoryNamed<TEntity>
          where TEntity : class, IEntityNamed
    {

        public EntityFrameworkRepositoryNamed(DbContext context, IIdentityUser identityUser, IManagerDateTime managerDateTime)
            : base(context)
        {

        }


        public TEntity Get(string codigo)
        {
            return GetSet().Where(c => c.Codigo == codigo).SingleOrDefault();
        }

        public TEntity Get(string codigo, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetSet().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            query = query.Where(c => c.Codigo == codigo);

            return query.SingleOrDefault();
        }
    }
}
