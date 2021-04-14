using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLTS.WebApi.DtoModels
{
    interface IApiControllerBase<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity>
    {
        /// <summary>
        /// Get object by Primary key reference
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
         Task<ActionResult<TDtoEntity>> GetById(TPrimaryKey primaryKey);

        /// <summary>
        /// Get object collection by Primary key reference
        /// </summary>
        /// <param name="primaryKeyCollection"></param>
        /// <returns></returns>
        Task<ActionResult<List<TDtoEntity>>> GetAllById(List<TPrimaryKey> primaryKeyCollection);

        /// <summary>
        /// Get all objects in a sorted paged collection
        /// </summary>
        /// <param name="sortRequest"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
         Task<ActionResult<PagedResultDtoEntity<TDtoEntity>>> GetAll(string sortRequest = "Id desc", int skipCount = 0, int maxResultCount = 99);

        /// <summary>
        /// Get first object by partially populated object search
        /// </summary>
        /// <param name="exampleSearchEntity"></param>
        /// <returns></returns>
        Task<ActionResult<TDtoEntity>> GetByExample(TDtoEntity exampleSearchEntity);

        /// <summary>
        /// Get all objects by partially populated object search in a sorted paged collection
        /// </summary>
        /// <param name="exampleSearchEntityPagingRequest"></param>
        /// <returns></returns>
         Task<ActionResult<PagedResultDtoEntity<TDtoEntity>>> GetAllByExample(PagedResultRequestDtoEntity<TDtoEntity> exampleSearchEntityPagingRequest);

        /// <summary>
        /// Save object, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="saveEntity"></param>
        /// <returns></returns>
         Task<ActionResult<TDtoEntity>> Save(TDtoEntity saveEntity);

        /// <summary>
        /// Save object collection, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="saveEntityCollection"></param>
        /// <returns></returns>
         Task<ActionResult<bool>> SaveCollection(List<TDtoEntity> saveEntityCollection);

        /// <summary>
        /// Delete requested object by primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="isSoftDelete"></param>
        /// <returns></returns>
         Task<ActionResult<bool>> Delete(TPrimaryKey primaryKey, bool isSoftDelete = false);

        /// <summary>
        /// Delete requested collection of objects by primary key
        /// </summary>
        /// <param name="primaryKeyCollection"></param>
        /// <returns></returns>
        Task<ActionResult<bool>> DeleteCollection(List<TDeleteDtoEntity> primaryKeyCollection);
    }
}