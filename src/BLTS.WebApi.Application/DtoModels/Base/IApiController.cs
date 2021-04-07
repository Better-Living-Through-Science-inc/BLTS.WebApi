using BLTS.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLTS.WebApi.DtoModels
{
    interface IApiController<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity>
    {
        /// <summary>
        /// Get object by Primary key reference
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TDtoEntity> GetById(TPrimaryKey input);
        /// <summary>
        /// Get all objects in a sorted paged collection
        /// </summary>
        /// <param name="sorting"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        Task<PagedResultDtoEntity<TDtoEntity>> GetAll(string sortRequest = "Id desc", int skipCount = 0, int maxResultCount = 99);
        /// <summary>
        /// Get first object by partially populated object search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TDtoEntity> GetByExample(TDtoEntity input);
        /// <summary>
        /// Get all objects by partially populated object search in a sorted paged collection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDtoEntity<TDtoEntity>> GetAllByExample(PagedResultRequestDtoEntity<TDtoEntity> pagingRequest);

        /// <summary>
        /// Save object, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="input"></param>
        /// <returns>is success</returns>
        Task<TDtoEntity> Save(TDtoEntity input);
        /// <summary>
        /// Save object collection, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="input"></param>
        /// <returns>is success</returns>
        Task<bool> SaveCollection(List<TDtoEntity> input);

        /// <summary>
        /// Delete requested object by primary key
        /// </summary>
        /// <param name="input"></param>
        /// <returns>is success</returns>
        Task<bool> Delete(TPrimaryKey primaryKey, bool isSoftDelete = false);
        /// <summary>
        /// Delete requested object collection by primary key
        /// </summary>
        /// <param name="input"></param>
        /// <returns>is success</returns>
        Task<bool> DeleteCollection(List<TDeleteDtoEntity> input);
    }
}