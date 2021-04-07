using BLTS.WebApi.Models;
using BLTS.WebApi.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BLTS.WebApi.Infrastructure.Database
{
    public class Repository<TEntity, TPrimaryKey, TDbContext> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        protected readonly ReflectionTools _reflectionTools;
        protected readonly TDbContext _context;
        public Repository(IServiceProvider serviceProvider
                        , ReflectionTools reflectionTools)
        {
            _context = serviceProvider.GetRequiredService<TDbContext>();
            _reflectionTools = reflectionTools;
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        public int UnitOfWorkComplete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        public async Task<int> UnitOfWorkCompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region Get
        /// <summary>
        /// returns unordered list of all entities that match the expression
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        /// <summary>
        /// search results by parameter like
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Get(TEntity entity)
        {
            return SearchByPartiallyPopulatedEntity(entity)?.FirstOrDefault();
        }

        /// <summary>
        /// returns entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(TPrimaryKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// returns entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// returns list of entity by primary key lookup
        /// </summary>
        /// <param name="idCollection"></param>
        /// <returns></returns>
        public List<TEntity> GetAll(List<TPrimaryKey> idCollection)
        {
            return _context.Set<TEntity>().AsEnumerable().Where(singleEntity => idCollection.Any(lookupId => singleEntity.Id.Equals(lookupId))).ToList();
        }

        /// <summary>
        /// search results by parameter like
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IPagedResultEntity<TEntity> GetAll(IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = null)
        {
            PagedResultEntity<TEntity> pagedResultEntity = new PagedResultEntity<TEntity>();
            IQueryable<TEntity> searchQuery;

            if (pagedResultRequestEntity != null && pagedResultRequestEntity.ObjectFilter != null)
                searchQuery = SearchByPartiallyPopulatedEntity(pagedResultRequestEntity.ObjectFilter).AsQueryable();
            else
                searchQuery = _context.Set<TEntity>().AsQueryable();

            pagedResultEntity.TotalCount = searchQuery.Count();
            pagedResultEntity.ItemCollection = searchQuery.PagedSorted(pagedResultRequestEntity).ToList();

            return pagedResultEntity;
        }
        #endregion

        #region Save
        /// <summary>
        /// saves list of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(IEnumerable<TEntity> entity, bool autoCommit = true)
        {
            try
            {
                _context.Set<TEntity>().AddRange(entity);
                if (autoCommit)
                    UnitOfWorkComplete();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// saves entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Insert(TEntity entity, bool autoCommit = true)
        {
            entity = _context.Set<TEntity>().Add(entity).Entity;
            if (autoCommit)
                UnitOfWorkComplete();

            return entity;
        }

        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(IEnumerable<TEntity> entity, bool autoCommit = true)
        {
            bool isSuccess = Update(entity.Where(singleEntity => !singleEntity.Id.Equals(default(TPrimaryKey))).ToList())
                          && Insert(entity.Where(singleEntity => singleEntity.Id.Equals(default(TPrimaryKey))).ToList());
            if (autoCommit)
                if (isSuccess)
                    UnitOfWorkComplete();

            return isSuccess;
        }

        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Save(TEntity entity, bool autoCommit = true)
        {
            if (!entity.Id.Equals(default(TPrimaryKey)))
                return Update(entity, autoCommit);
            else
                return Insert(entity, autoCommit);
        }

        /// <summary>
        /// saves list of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(IEnumerable<TEntity> entity, bool autoCommit = true)
        {
            try
            {
                _context.Set<TEntity>().UpdateRange(entity);
                if (autoCommit)
                    UnitOfWorkComplete();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// saves entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity, bool autoCommit = true)
        {
            entity = _context.Set<TEntity>().Update(entity).Entity;
            if (autoCommit)
                UnitOfWorkComplete();

            return entity;
        }
        #endregion

        #region Delete
        /// <summary>
        /// deletes list of entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(List<TEntity> entity, bool autoCommit = true)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entity);
                if (autoCommit)
                    UnitOfWorkComplete();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// deletes entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity, bool autoCommit = true)
        {
            try
            {
                entity = _context.Set<TEntity>().Remove(entity).Entity;
                if (autoCommit)
                    UnitOfWorkComplete();
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Private Utility Methods
        /// <summary>
        /// performs a partially populated search of the objects in the DB
        /// </summary>
        /// <param name="entity">non default, non null values used to filter result set</param>
        /// <returns></returns>
        private IEnumerable<TEntity> SearchByPartiallyPopulatedEntity(TEntity entity)
        {
            ConcurrentDictionary<PropertyInfo, dynamic> objectPropertyDictionary = _reflectionTools.ValidPropertiesForSearch(entity, false, true, true);

            return _context.Set<TEntity>().AsEnumerable()
                                          .Where(singleEntity => objectPropertyDictionary.Any(singleProperty => singleProperty.Key.GetValue(singleEntity, null).Equals(singleProperty.Value)));
        }
        #endregion
    }
}


