using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLTS.WebApi.Models
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        int UnitOfWorkComplete();
        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        Task<int> UnitOfWorkCompleteAsync();

        #region Get
        /// <summary>
        /// returns unordered list of all entities that match the expression
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// search results by parameter like
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Get(TEntity entity);
        /// <summary>
        /// returns entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TPrimaryKey id);
        /// <summary>
        /// returns entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPrimaryKey id);
        /// <summary>
        /// returns list of entity by primary key lookup
        /// </summary>
        /// <param name="idCollection"></param>
        /// <returns></returns>
        List<TEntity> GetAll(List<TPrimaryKey> idCollection);
        /// <summary>
        /// search results by parameter like
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IPagedResultEntity<TEntity> GetAll(IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = null);
        #endregion

        #region Save
        /// <summary>
        /// saves list of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Insert(IEnumerable<TEntity> entity, bool autoCommit = true);
        /// <summary>
        /// saves entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Insert(TEntity entity, bool autoCommit = true);
        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Save(IEnumerable<TEntity> entity, bool autoCommit = true);
        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Save(TEntity entity, bool autoCommit = true);
        /// <summary>
        /// saves list of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(IEnumerable<TEntity> entity, bool autoCommit = true);
        /// <summary>
        /// saves entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity, bool autoCommit = true);
        #endregion

        #region Delete
        /// <summary>
        /// deletes list of entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(List<TEntity> entity, bool autoCommit = true);
        /// <summary>
        /// deletes entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(TEntity entity, bool autoCommit = true);
        #endregion
    }
}
