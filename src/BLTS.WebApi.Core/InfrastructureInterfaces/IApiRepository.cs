using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLTS.WebApi.InfrastructureInterfaces
{
    public interface IApiRepository<TEntity, TEntityDto, TEntityCreateUpdateDto, TPrimaryKey> where TEntity : new()
    {
        bool Delete(TEntity entity);
        bool Delete(List<TEntity> entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(List<TEntity> entity);
        TEntity Get(TPrimaryKey id);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TPrimaryKey id);
        bool Insert(TEntity entity);
        bool Insert(List<TEntity> entity);
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> InsertAsync(List<TEntity> entity);
        bool Save(TEntity entity);
        bool Save(List<TEntity> entity);
        Task<bool> SaveAsync(TEntity entity);
        Task<bool> SaveAsync(List<TEntity> entity);
        bool Update(TEntity entity);
        bool Update(List<TEntity> entity);
        Task<bool> UpdateAsync(TEntity entity);
    }
}
