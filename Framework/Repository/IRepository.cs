﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Repository
{
    /// <summary>
    /// Base interface for implement a "Repository Pattern", for
    /// more information about this pattern see http://martinfowler.com/eaaCatalog/repository.html
    /// or http://blogs.msdn.com/adonet/archive/2009/06/16/using-repository-and-unit-of-work-patterns-with-entity-framework-4-0.aspx
    /// </summary>
    /// <remarks>
    /// Indeed, one might think that IDbSet already a generic repository and therefore
    /// would not need this item. Using this interface allows us to ensure PI principle
    /// within our domain model
    /// </remarks>
    /// <typeparam name="TEntity">Type of entity for this repository </typeparam>
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, IEntity
    {

        /// <summary>
        /// IQueryable. JSA. Analizar si se permite acceder directamente a la entidad, dando más flexibilidad y menos control
        /// </summary>
        //IQueryable<TEntity> Query;

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Get element by entity key. Too include properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        //TEntity Get(int id,params Expression<Func<TEntity, object>>[] includeProperties);


        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetList();

        /// <summary>
        /// Obtener listado de las entidad, basado en criteria 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> criteria);


        /// <summary>
        /// Obtener listado de las entidad, basado en paginacion, criteria y orden
        /// con query y tamaño de pagina definida en parametro sistema
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="criteria"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        IPagedListMetaData<TEntity> GetList<TKey>(int pagina, Expression<Func<TEntity, bool>> criteria = null, Expression<Func<TEntity, TKey>> orden = null);

        /// <summary>
        /// Obtener listado de las entidad, basado en paginacion, criteria y orden
        /// </summary>
        /// <param name="Skip"></param>
        /// <param name="Take"></param>
        /// <param name="criteria"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        IPagedListMetaData<TEntity> GetList<TKey>(int Skip, int Take, Expression<Func<TEntity, bool>> criteria = null, Expression<Func<TEntity, TKey>> orden = null);

        /// <summary>
        /// Obtener listado de las entidades, incluidas las propiedades establecidas en los parametros
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetListIncluding(params Expression<Func<TEntity, object>>[] includeProperties);


        /// <summary>
        /// Get  elements of type TEntity in repository filter and include properties set
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetListIncluding(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includeProperties);


        //IEnumerable<T> GetList<T>(Expression<Func<T, bool>> criteria, int Skip, int Take)

        //IList<T> GetList<T>(Expression<Func<T, bool>> criteria, int? MaxResults);
        //IList<T> GetList<T>(IList<Expression<Func<T, bool>>> criteria);

        /// <summary>
        /// For entities with automatatically generated Ids, such as identity, SaveOrUpdate may 
        /// be called when saving or updating an entity.
        /// 
        /// Updating also allows you to commit changes to a detached object.  More info may be found at:
        /// http://www.hibernate.org/hib_docs/nhibernate/html_single/#manipulatingdata-updating-detached
        /// </summary>
        TEntity SaveOrUpdate(TEntity entity);

        /// <summary>
        /// Guardar o actualizar una lista de entidades
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        IList<TEntity> SaveOrUpdate(IList<TEntity> listEntity);



        /// <summary>
        /// I'll let you guess what this does.
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// Eliminar una lista de entidades
        /// </summary>
        /// <param name="listEntity"></param>
        void Delete(IList<TEntity> listEntity);

        /// <summary>
        /// Verificar si existe un objeto de tipo TEntity, segun el criterio pasado por parametro existe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> criteria);



        ///// <summary>
        ///// Get all elements of type TEntity that matching a
        ///// Specification <paramref name="specification"/>
        ///// </summary>
        ///// <param name="specification">Specification that result meet</param>
        ///// <returns></returns>
        //IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification);



        ///// <summary>
        ///// Get all elements of type TEntity in repository
        ///// </summary>
        ///// <param name="pageIndex">Page index</param>
        ///// <param name="pageCount">Number of elements in each page</param>
        ///// <param name="orderByExpression">Order by expression for this query</param>
        ///// <param name="ascending">Specify if order is ascending</param>
        ///// <returns>List of selected elements</returns>
        //IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);

        ///// <summary>
        ///// Get  elements of type TEntity in repository
        ///// </summary>
        ///// <param name="filter">Filter that each element do match</param>
        ///// <returns>List of selected elements</returns>
        //IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get a IQueryable object for an entity in the model
        /// </summary>
        /// <typeparam name="T">Type of entity in model</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An IQueryable&lt;T>, if predicate is not null then contains elements from the input sequence that satisfy the condition specified by predicate.</returns>
        IQueryable<TSource> GetQuery<TSource>(Expression<Func<TSource, bool>> predicate = null) where TSource : class, IEntity;

        /// <summary>
        /// Get a IQueryable object of type TEntity in repository
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An IQueryable&lt;TEntity>, if predicate is not null then contains elements from the input sequence that satisfy the condition specified by predicate.</returns>
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null);
    }



    public interface IRepositoryNamed<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntityNamed
    {


        /// <summary>
        /// Get Elmento by codigo 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        TEntity Get(string codigo);

        /// <summary>
        /// Obtener elemento de la entidad nombrada, tambien se puede establecer que propiedades adicionales (Propiedadas con lazy load)
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity Get(string codigo, params Expression<Func<TEntity, object>>[] includeProperties);



    }
}
