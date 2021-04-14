using AutoMapper;
using AutoMapper.Internal;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLTS.WebApi.ApiControllers
{
    /// <summary>
    /// Generic API controller for non permission based data access 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDtoEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TDeleteDtoEntity"></typeparam>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity> : ControllerBase, IApiControllerBase<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TDtoEntity : class, IDtoEntity<TPrimaryKey>, new()
        where TDeleteDtoEntity : class, IDeleteDtoEntity<TPrimaryKey>, new()
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="applicationLogTools"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ApiControllerBase(IApplicationLogTools applicationLogTools
                               , IRepository<TEntity, TPrimaryKey> repository
                               , IMapper mapper)
        {
            _applicationLogTools = applicationLogTools;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get object by Primary key reference
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ActionResult<TDtoEntity>> GetById(TPrimaryKey primaryKey)
        {
            try
            {
                TEntity requestedObject = await _repository.GetAsync(primaryKey);
                if (requestedObject != null)
                    return Ok(MapToDtoEntity(requestedObject));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Get object collection by Primary key reference
        /// </summary>
        /// <param name="primaryKeyCollection"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ActionResult<List<TDtoEntity>>> GetAllById(List<TPrimaryKey> primaryKeyCollection)
        {
            try
            {
                List<TEntity> requestedCollection = _repository.GetAll(primaryKeyCollection);
                if (requestedCollection.Count > 0)
                    return Ok(MapToDtoEntityCollection(requestedCollection));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Get all objects in a sorted paged collection
        /// </summary>
        /// <param name="sortRequest"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ActionResult<PagedResultDtoEntity<TDtoEntity>>> GetAll(string sortRequest = "Id desc", int skipCount = 0, int maxResultCount = 99)
        {
            try
            {
                PagedResultRequestDtoEntity<TEntity> pagingRequest = new PagedResultRequestDtoEntity<TEntity>() { SortRequest = sortRequest, SkipCount = skipCount, MaxResultCount = maxResultCount };
                IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = _mapper.Map<IPagedResultRequestEntity<TEntity>>(pagingRequest);

                IPagedResultEntity<TEntity> requestedCollection = _repository.GetAll(pagedResultRequestEntity);
                if (requestedCollection.TotalCount > 0)
                    return Ok(MapToPagedResultDtoEntity(_repository.GetAll(pagedResultRequestEntity)));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Get first object by partially populated object search
        /// </summary>
        /// <param name="exampleSearchEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<TDtoEntity>> GetByExample(TDtoEntity exampleSearchEntity)
        {
            try
            {
                TEntity requestedObject = _repository.Get(MapToEntity(exampleSearchEntity));
                if (requestedObject != null)
                    return Ok(MapToDtoEntity(requestedObject));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Get all objects by partially populated object search in a sorted paged collection
        /// </summary>
        /// <param name="exampleSearchEntityPagingRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<PagedResultDtoEntity<TDtoEntity>>> GetAllByExample(PagedResultRequestDtoEntity<TDtoEntity> exampleSearchEntityPagingRequest)
        {
            try
            {
                IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = _mapper.Map<IPagedResultRequestEntity<TEntity>>(exampleSearchEntityPagingRequest);

                IPagedResultEntity<TEntity> requestedCollection = _repository.GetAll(pagedResultRequestEntity);
                if (requestedCollection.TotalCount > 0)
                    return Ok(MapToPagedResultDtoEntity(_repository.GetAll(pagedResultRequestEntity)));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Save object, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="saveEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<TDtoEntity>> Save(TDtoEntity saveEntity)
        {
            try
            {
                TEntity requestedSaveObject = _repository.Save(MapToEntity(saveEntity));
                if (requestedSaveObject != null)
                    return Ok(MapToDtoEntity(requestedSaveObject));
                else
                    return base.UnprocessableEntity(saveEntity);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Save object collection, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="saveEntityCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<bool>> SaveCollection(List<TDtoEntity> saveEntityCollection)
        {
            try
            {
                if (_repository.Save(MapToEntityCollection(saveEntityCollection)))
                    return Ok(true);
                else
                    return base.UnprocessableEntity(false);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Delete requested object by primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="isSoftDelete"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<ActionResult<bool>> Delete(TPrimaryKey primaryKey, bool isSoftDelete = false)
        {
            try
            {
                return await DeleteCollection(new List<TDeleteDtoEntity>() { new TDeleteDtoEntity() { Id = primaryKey, IsSoftDelete = isSoftDelete } });
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Delete requested collection of objects by primary key
        /// </summary>
        /// <param name="primaryKeyCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<bool>> DeleteCollection(List<TDeleteDtoEntity> primaryKeyCollection)
        {
            bool isSuccess = true;//returns true for empty collection
            try
            {
                Dictionary<string, List<TPrimaryKey>> deleteTypeDictionary = primaryKeyCollection.GroupBy(softDeleteGroup => softDeleteGroup.IsSoftDelete)
                                                                                  .ToDictionary(singleDeleteRequest => singleDeleteRequest.Key ? "Soft" : "Hard"
                                                                                              , singleDeleteRequest => new List<TPrimaryKey>(singleDeleteRequest.Select(singleDeleteRequest => singleDeleteRequest.Id))
                                                                                  );

                if (deleteTypeDictionary.ContainsKey("Soft"))
                {
                    List<TEntity> softDeleteCollection = _repository.GetAll(deleteTypeDictionary["Soft"]);
                    softDeleteCollection.AsParallel().ForAll(singleObject => singleObject.IsDeleted = true);
                    isSuccess &= _repository.Save(softDeleteCollection);
                }

                if (deleteTypeDictionary.ContainsKey("Hard"))
                {
                    List<TEntity> hardDeleteCollection = _repository.GetAll(deleteTypeDictionary["Hard"]);
                    isSuccess &= _repository.Delete(hardDeleteCollection);
                }

            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }

            if (isSuccess)
                return Ok(true);
            else
                return base.UnprocessableEntity(isSuccess);
        }

        internal virtual TEntity MapToEntity(TDtoEntity dtoEntity)
        {
            try
            {
                return _mapper.Map<TEntity>(dtoEntity);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw;
            }
        }

        internal virtual TDtoEntity MapToDtoEntity(TEntity internalEntity)
        {
            try
            {
                return _mapper.Map<TDtoEntity>(internalEntity);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw;
            }
        }

        internal virtual List<TEntity> MapToEntityCollection(List<TDtoEntity> dtoEntityCollection)
        {
            try
            {
                return _mapper.Map<List<TEntity>>(dtoEntityCollection);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw;
            }
        }

        internal virtual List<TDtoEntity> MapToDtoEntityCollection(List<TEntity> internalEntityCollection)
        {
            try
            {
                return _mapper.Map<List<TDtoEntity>>(internalEntityCollection);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw;
            }
        }

        internal virtual PagedResultDtoEntity<TDtoEntity> MapToPagedResultDtoEntity(IPagedResultEntity<TEntity> pagedResultEntity)
        {
            try
            {
                return _mapper.Map<PagedResultDtoEntity<TDtoEntity>>(pagedResultEntity);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw;
            }
        }
    }
}