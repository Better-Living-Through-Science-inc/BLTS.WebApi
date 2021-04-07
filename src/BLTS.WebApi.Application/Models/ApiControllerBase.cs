using AutoMapper;
using AutoMapper.Internal;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLTS.WebApi.DtoModels
{
    public abstract class ApiControllerBase<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity> : ControllerBase, IApiControllerBase<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TDtoEntity : IDtoEntity<TPrimaryKey>, new()
        where TDeleteDtoEntity : IDeleteDtoEntity<TPrimaryKey>, new()
    {
        private readonly IApplicationLogTools _applicationLogTools;
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IMapper _mapper;

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
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<TDtoEntity> GetById(TPrimaryKey input)
        {
            try
            {
                return MapToDtoEntity(await _repository.GetAsync(input));
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Get object collection by Primary key reference
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<List<TDtoEntity>> GetAllById(List<TPrimaryKey> input)
        {
            try
            {
                return MapToDtoEntityCollection(_repository.GetAll(input));
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Get all objects in a sorted paged collection
        /// </summary>
        /// <param name="sorting"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<PagedResultDtoEntity<TDtoEntity>> GetAll(string sortRequest = "Id desc", int skipCount = 0, int maxResultCount = 99)
        {
            try
            {
                PagedResultRequestDtoEntity<TEntity> pagingRequest = new PagedResultRequestDtoEntity<TEntity>() { SortRequest = sortRequest, SkipCount = skipCount, MaxResultCount = maxResultCount };
                IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = _mapper.Map<IPagedResultRequestEntity<TEntity>>(pagingRequest);

                PagedResultDtoEntity<TDtoEntity> pagedResultDtoEntity = MapToPagedResultDtoEntity(_repository.GetAll(pagedResultRequestEntity));

                return pagedResultDtoEntity;
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Get first object by partially populated object search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<TDtoEntity> GetByExample(TDtoEntity input)
        {
            try
            {
                return MapToDtoEntity(_repository.Get(MapToEntity(input)));
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Get all objects by partially populated object search in a sorted paged collection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<PagedResultDtoEntity<TDtoEntity>> GetAllByExample(PagedResultRequestDtoEntity<TDtoEntity> pagingRequest)
        {
            try
            {
                IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = _mapper.Map<IPagedResultRequestEntity<TEntity>>(pagingRequest);

                PagedResultDtoEntity<TDtoEntity> pagedResultDtoEntity = MapToPagedResultDtoEntity(_repository.GetAll(pagedResultRequestEntity));

                return pagedResultDtoEntity;
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Save object, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<TDtoEntity> Save(TDtoEntity input)
        {
            try
            {
                return MapToDtoEntity(_repository.Save(MapToEntity(input)));
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Save object collection, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<bool> SaveCollection(List<TDtoEntity> input)
        {
            try
            {
                return _repository.Save(MapToEntityCollection(input));
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Delete requested object by primary key
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<bool> Delete(TPrimaryKey primaryKey, bool isSoftDelete = false)
        {
            try
            {
                return await DeleteCollection(new List<TDeleteDtoEntity>() { new TDeleteDtoEntity() { Id = primaryKey, IsSoftDelete = isSoftDelete } });
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        /// <summary>
        /// Delete requested collection of objects by primary key
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<bool> DeleteCollection(List<TDeleteDtoEntity> input)
        {
            bool isSuccess = true;//returns true for empty collection
            try
            {
                Dictionary<string, List<TPrimaryKey>> deleteTypeDictionary = input.GroupBy(softDeleteGroup => softDeleteGroup.IsSoftDelete)
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
                isSuccess = false;
            }

            return isSuccess;
        }

        internal virtual TEntity MapToEntity(TDtoEntity input)
        {
            try
            {
                return _mapper.Map<TEntity>(input);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        internal virtual TDtoEntity MapToDtoEntity(TEntity input)
        {
            try
            {
                return _mapper.Map<TDtoEntity>(input);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        internal virtual List<TEntity> MapToEntityCollection(List<TDtoEntity> input)
        {
            try
            {
                return _mapper.Map<List<TEntity>>(input);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        internal virtual List<TDtoEntity> MapToDtoEntityCollection(List<TEntity> input)
        {
            try
            {
                return _mapper.Map<List<TDtoEntity>>(input);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }

        internal virtual PagedResultDtoEntity<TDtoEntity> MapToPagedResultDtoEntity(IPagedResultEntity<TEntity> input)
        {
            try
            {
                return _mapper.Map<PagedResultDtoEntity<TDtoEntity>>(input);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"WebApi.ApiControllerBase<{typeof(TEntity).Name}>" } });
                throw apiControllerError;
            }
        }
    }
}