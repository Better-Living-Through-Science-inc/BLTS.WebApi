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
    public abstract class ApiController<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity> : ControllerBase, IApiController<TEntity, TDtoEntity, TPrimaryKey, TDeleteDtoEntity>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TDtoEntity : IDtoEntity<TPrimaryKey>, new()
        where TDeleteDtoEntity : IDeleteDtoEntity<TPrimaryKey>, new()
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;
        protected readonly IMapper _mapper;

        public ApiController(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Get object by Primary key reference
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<TDtoEntity> GetById(TPrimaryKey input)
        {
            return MapToDtoEntity(await _repository.GetAsync(input));
        }

        /// <summary>
        /// Get object collection by Primary key reference
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<List<TDtoEntity>> GetAllById(List<TPrimaryKey> input)
        {
            return MapToDtoEntityCollection(_repository.GetAll(input));
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
            PagedResultRequestDtoEntity<TEntity> pagingRequest = new PagedResultRequestDtoEntity<TEntity>() { SortRequest = sortRequest, SkipCount = skipCount, MaxResultCount = maxResultCount };
            IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = _mapper.Map<IPagedResultRequestEntity<TEntity>>(pagingRequest);

            PagedResultDtoEntity<TDtoEntity> pagedResultDtoEntity = MapToPagedResultDtoEntity(_repository.GetAll(pagedResultRequestEntity));

            return pagedResultDtoEntity;
        }

        /// <summary>
        /// Get first object by partially populated object search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<TDtoEntity> GetByExample(TDtoEntity input)
        {
            return MapToDtoEntity(_repository.Get(MapToEntity(input)));
        }

        /// <summary>
        /// Get all objects by partially populated object search in a sorted paged collection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<PagedResultDtoEntity<TDtoEntity>> GetAllByExample(PagedResultRequestDtoEntity<TDtoEntity> pagingRequest)
        {
            IPagedResultRequestEntity<TEntity> pagedResultRequestEntity = _mapper.Map<IPagedResultRequestEntity<TEntity>>(pagingRequest);

            PagedResultDtoEntity<TDtoEntity> pagedResultDtoEntity = MapToPagedResultDtoEntity(_repository.GetAll(pagedResultRequestEntity));

            return pagedResultDtoEntity;
        }

        /// <summary>
        /// Save object, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<TDtoEntity> Save(TDtoEntity input)
        {
            return MapToDtoEntity(_repository.Save(MapToEntity(input)));
        }

        /// <summary>
        /// Save object collection, insert will be performed where PK = null or default value, else update will be performed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<bool> SaveCollection(List<TDtoEntity> input)
        {
            return _repository.Save(MapToEntityCollection(input));
        }

        /// <summary>
        /// Delete requested object by primary key
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<bool> Delete(TPrimaryKey primaryKey, bool isSoftDelete = false)
        {
            return await DeleteCollection(new List<TDeleteDtoEntity>() { new TDeleteDtoEntity() { Id = primaryKey, IsSoftDelete = isSoftDelete } });
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
            catch (Exception asdf)
            {
                string asfasdfasfd = asdf.ToString();
                isSuccess = false;
            }

            return isSuccess;
        }

        internal virtual TEntity MapToEntity(TDtoEntity input)
        {
            return _mapper.Map<TEntity>(input);
        }

        internal virtual TDtoEntity MapToDtoEntity(TEntity input)
        {
            return _mapper.Map<TDtoEntity>(input);
        }

        internal virtual List<TEntity> MapToEntityCollection(List<TDtoEntity> input)
        {
            return _mapper.Map<List<TEntity>>(input);
        }

        internal virtual List<TDtoEntity> MapToDtoEntityCollection(List<TEntity> input)
        {
            return _mapper.Map<List<TDtoEntity>>(input);
        }

        internal virtual PagedResultDtoEntity<TDtoEntity> MapToPagedResultDtoEntity(IPagedResultEntity<TEntity> input)
        {
            return _mapper.Map<PagedResultDtoEntity<TDtoEntity>>(input);
        }
    }
}