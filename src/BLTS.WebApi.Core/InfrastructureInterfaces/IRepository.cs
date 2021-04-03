using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLTS.WebApi.InfrastructureInterfaces
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : new()
    {
        #region Get
        public List<TEntity> GetAll();
        public TEntity Get(TPrimaryKey id);
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        #endregion

        #region Save
        public TEntity Insert(TEntity entity, bool autoCommit = true);
        public void Insert(IEnumerable<TEntity> entity, bool autoCommit = true);
        public TEntity Save(TEntity entity, bool autoCommit = true);
        public void Save(IEnumerable<TEntity> entity, bool autoCommit = true);
        public TEntity Update(TEntity entity, bool autoCommit = true);
        public void Update(IEnumerable<TEntity> entity, bool autoCommit = true);
        #endregion

        #region Delete
        public TEntity Delete(TEntity entity, bool autoCommit = true);
        public void Delete(List<TEntity> entity, bool autoCommit = true);
        #endregion
    }
}
