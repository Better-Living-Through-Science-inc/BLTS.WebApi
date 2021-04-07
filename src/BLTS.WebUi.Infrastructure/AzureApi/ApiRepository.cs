using AutoMapper;
using BLTS.WebApi.Configurations;
using BLTS.WebApi.Infrastructure.AzureApi.Models;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLTS.WebApi.Infrastructure.AzureApi
{
    public class ApiRepository<TEntity, TEntityDto, TEntityCreateUpdateDto, TPrimaryKey> : IApiRepository<TEntity, TEntityDto, TEntityCreateUpdateDto, TPrimaryKey> where TEntity : Entity<TPrimaryKey>, new()
    {
        private readonly ApiAuthentication _apiAuthentication;
        private readonly ApplicationLogTools _applicationLogTools;
        private readonly ConfigurationManager _configurationManager;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ApiRepository(ApiAuthentication apiAuthentication
                           , ApplicationLogTools applicationLogTools
                           , ConfigurationManager configurationManager
                           , HttpClient httpClient
                           , IMapper mapper)
        {
            _apiAuthentication = apiAuthentication;
            _applicationLogTools = applicationLogTools;
            _configurationManager = configurationManager;
            _httpClient = httpClient;
            _mapper = mapper;
        }


        #region Get
        /// <summary>
        /// returns unordered list of all entities stored
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await ApiGetAsync();
        }
        /// <summary>
        /// returns unordered list of all entities stored
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            return ApiGetAsync().Result;
        }

        /// <summary>
        /// returns entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await ApiGetAsync(id);
        }
        /// <summary>
        /// returns entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(TPrimaryKey id)
        {
            return ApiGetAsync(id).Result;
        }
        #endregion

        #region Save
        /// <summary>
        /// saves entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(TEntity entity)
        {
            return await ApiPostAsync(entity);
        }
        /// <summary>
        /// saves entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(TEntity entity)
        {
            return ApiPostAsync(entity).Result;
        }
        /// <summary>
        /// saves list of entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="runInTransaction"></param>
        /// <returns></returns>

        public async Task<bool> InsertAsync(List<TEntity> entityCollection)
        {
            return await ApiPostAsync(entityCollection);
        }
        /// <summary>
        /// saves list of entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="runInTransaction"></param>
        /// <returns></returns>
        public bool Insert(List<TEntity> entityCollection)
        {
            return ApiPostAsync(entityCollection).Result;
        }

        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0 and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(TEntity entity)
        {
            if (!entity.Id.Equals(default(TPrimaryKey)))
                return await UpdateAsync(entity);
            else
                return await InsertAsync(entity);
        }
        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0 and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(TEntity entity)
        {
            if (!entity.Id.Equals(default(TPrimaryKey)))
                return Update(entity);
            else
                return Insert(entity);
        }

        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0 and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(List<TEntity> entityCollection)
        {
            return await UpdateAsync(entityCollection.Where(singleEntity => !singleEntity.Id.Equals(default(TPrimaryKey))).ToList())
                && await InsertAsync(entityCollection.Where(singleEntity => singleEntity.Id.Equals(default(TPrimaryKey))).ToList());
        }
        /// <summary>
        /// pass through for the auto selected insert or update based on Id = 0 and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(List<TEntity> entityCollection)
        {
            return Update(entityCollection.Where(singleEntity => !singleEntity.Id.Equals(default(TPrimaryKey))).ToList())
                && Insert(entityCollection.Where(singleEntity => singleEntity.Id.Equals(default(TPrimaryKey))).ToList());
        }

        /// <summary>
        /// saves entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await ApiPutAsync(entity);
        }
        /// <summary>
        /// saves entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(TEntity entity)
        {
            return ApiPutAsync(entity).Result;
        }

        /// <summary>
        /// saves list of entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(List<TEntity> entityCollection)
        {
            return await ApiPutAsync(entityCollection);
        }
        /// <summary>
        /// saves list of entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(List<TEntity> entityCollection)
        {
            return ApiPutAsync(entityCollection).Result;
        }
        #endregion

        #region Delete
        /// <summary>
        /// deletes entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await ApiDeleteAsync(entity);
        }
        /// <summary>
        /// deletes entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(List<TEntity> entityCollection)
        {
            return await ApiDeleteAsync(entityCollection);
        }
        /// <summary>
        /// deletes entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity)
        {
            return ApiDeleteAsync(entity).Result;
        }
        /// <summary>
        /// deletes entity and returns success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(List<TEntity> entityCollection)
        {
            return ApiDeleteAsync(entityCollection).Result;
        }
        #endregion


        /// <summary>
        /// post object to API
        /// </summary>
        /// <param name="currentObject"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<bool> ApiDeleteAsync(TEntity currentObject, string subPathUri = null)
        {
            List<TEntity> currentDeleteCollection = new List<TEntity> { currentObject };
            return await ApiDeleteAsync(currentDeleteCollection, subPathUri);
        }

        /// <summary>
        /// post list of objects to API
        /// </summary>
        /// <param name="currentObject"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<bool> ApiDeleteAsync(List<TEntity> entityCollection, string subPathUri = null)
        {
            if (entityCollection.Count == 0)
                return true;

            if (string.IsNullOrWhiteSpace(subPathUri))
                subPathUri = "/api/app/" + typeof(TEntity).Name;

            try
            {
                if (_httpClient.BaseAddress == null)
                    _httpClient.BaseAddress = new Uri(_configurationManager.GetValue("ApiBaseAddress"));

                if (await _apiAuthentication.ExecuteLoginAsync(_httpClient) == true)
                {
                    foreach (TEntity singleObject in entityCollection.Where(singleObject => !singleObject.Id.Equals(default(TPrimaryKey))))
                    {
                        HttpResponseMessage response = _httpClient.DeleteAsync(subPathUri + "/" + singleObject.Id.ToString()).Result;
                        response.EnsureSuccessStatusCode();
                    }
                }
                return true;
            }
            catch (Exception apiCommunicationError)
            {
                _applicationLogTools.LogError(apiCommunicationError, new Dictionary<string, dynamic> { { "MethodName", "ApiDeleteAsync(List<TEntity> currentDeleteCollection, string subPathUri = null)" }, { "ClassName", "ApiRepository " + typeof(TEntity).Name } });
            }

            return false;
        }

        /// <summary>
        /// Get entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<TEntity> ApiGetAsync(TPrimaryKey id, string subPathUri = null)
        {
            TEntity currentReturnobject = null;
            if (string.IsNullOrWhiteSpace(subPathUri))
                subPathUri = "/api/app/" + typeof(TEntity).Name;

            try
            {
                _httpClient.BaseAddress = new Uri(_configurationManager.GetValue("ApiBaseAddress"));

                if (await _apiAuthentication.ExecuteLoginAsync(_httpClient) == true)
                {
                    HttpResponseMessage responseResult = _httpClient.GetAsync(subPathUri + "/" + id.ToString()).Result;
                    responseResult.EnsureSuccessStatusCode();

                    TEntityDto deserializedContent = JsonConvert.DeserializeObject<TEntityDto>(await responseResult.Content.ReadAsStringAsync());
                    currentReturnobject = _mapper.Map<TEntityDto, TEntity>(deserializedContent);
                }
            }
            catch (Exception apiCommunicationError)
            {
                _applicationLogTools.LogError(apiCommunicationError, new Dictionary<string, dynamic> { { "MethodName", "ApiGetAsync(TPrimaryKey id, string subPathUri = null)" }, { "ClassName", "ApiRepository " + typeof(TEntity).Name } });
            }

            return currentReturnobject;
        }

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<List<TEntity>> ApiGetAsync(string subPathUri = null)
        {
            List<TEntity> currentReturnCollection = null;
            if (string.IsNullOrWhiteSpace(subPathUri))
                subPathUri = "/api/app/" + typeof(TEntity).Name;

            try
            {
                if (_httpClient.BaseAddress == null)
                    _httpClient.BaseAddress = new Uri(_configurationManager.GetValue("ApiBaseAddress"));

                if (await _apiAuthentication.ExecuteLoginAsync(_httpClient) == true)
                {
                    HttpResponseMessage responseResult = _httpClient.GetAsync(subPathUri).Result;
                    responseResult.EnsureSuccessStatusCode();

                    ContentWrapper<TEntityDto> deserializedContent = JsonConvert.DeserializeObject<ContentWrapper<TEntityDto>>(await responseResult.Content.ReadAsStringAsync());

                    currentReturnCollection = _mapper.Map<List<TEntityDto>, List<TEntity>>(deserializedContent.Items);
                }
            }
            catch (Exception apiCommunicationError)
            {
                _applicationLogTools.LogError(apiCommunicationError, new Dictionary<string, dynamic> { { "MethodName", "ApiGetAsync(string subPathUri = null)" }, { "ClassName", "ApiRepository " + typeof(TEntity).Name } });
            }

            return currentReturnCollection;
        }

        /// <summary>
        /// post object to API
        /// </summary>
        /// <param name="currentObject"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<bool> ApiPostAsync(TEntity currentObject, string subPathUri = null)
        {
            List<TEntity> currentPostCollection = new List<TEntity> { currentObject };
            return await ApiPostAsync(currentPostCollection, subPathUri);
        }

        /// <summary>
        /// post list of objects to API
        /// </summary>
        /// <param name="currentObject"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<bool> ApiPostAsync(List<TEntity> entityCollection, string subPathUri = null)
        {
            if (entityCollection.Count == 0)
                return true;

            if (string.IsNullOrWhiteSpace(subPathUri))
                subPathUri = "/api/app/" + typeof(TEntity).Name;

            try
            {
                if (_httpClient.BaseAddress == null)
                    _httpClient.BaseAddress = new Uri(_configurationManager.GetValue("ApiBaseAddress"));

                if (await _apiAuthentication.ExecuteLoginAsync(_httpClient) == true)
                {
                    foreach (TEntity singleObject in entityCollection)
                    {
                        TEntityCreateUpdateDto singleCreateUpdateDto = _mapper.Map<TEntity, TEntityCreateUpdateDto>(singleObject);

                        HttpResponseMessage responseResult = _httpClient.PostAsJsonAsync(subPathUri, singleCreateUpdateDto).Result;
                        responseResult.EnsureSuccessStatusCode();

                        TEntityDto deserializedContent = JsonConvert.DeserializeObject<TEntityDto>(await responseResult.Content.ReadAsStringAsync());
                        TEntity currentReturnobject = _mapper.Map<TEntityDto, TEntity>(deserializedContent);

                        singleObject.Id = currentReturnobject.Id;
                    }
                }
                return true;
            }
            catch (Exception apiCommunicationError)
            {
                _applicationLogTools.LogError(apiCommunicationError, new Dictionary<string, dynamic> { { "MethodName", "ApiPostAsync(List<TEntity> currentObjectCollection, string subPathUri = null)" }, { "ClassName", $"ApiRepository {typeof(TEntity).Name }" } });
            }

            return false;
        }

        /// <summary>
        /// Put object to API
        /// </summary>
        /// <param name="currentObject"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<bool> ApiPutAsync(TEntity currentObject, string subPathUri = null)
        {
            List<TEntity> currentPostCollection = new List<TEntity> { currentObject };
            return await ApiPutAsync(currentPostCollection, subPathUri);
        }

        /// <summary>
        /// Put list of objects to API
        /// </summary>
        /// <param name="currentObject"></param>
        /// <param name="subPathUri"></param>
        /// <returns></returns>
        private async Task<bool> ApiPutAsync(List<TEntity> entityCollection, string subPathUri = null)
        {
            if (entityCollection.Count == 0)
                return true;

            if (string.IsNullOrWhiteSpace(subPathUri))
                subPathUri = "/api/app/" + typeof(TEntity).Name;

            try
            {
                if (_httpClient.BaseAddress == null)
                    _httpClient.BaseAddress = new Uri(_configurationManager.GetValue("ApiBaseAddress"));

                if (await _apiAuthentication.ExecuteLoginAsync(_httpClient) == true)
                {
                    foreach (TEntity singleObject in entityCollection)
                    {
                        TEntityCreateUpdateDto singleCreateUpdateDto = _mapper.Map<TEntity, TEntityCreateUpdateDto>(singleObject);

                        HttpResponseMessage responseResult = _httpClient.PutAsJsonAsync(subPathUri + "/" + singleObject.Id.ToString(), singleCreateUpdateDto).Result;
                        responseResult.EnsureSuccessStatusCode();

                        TEntityDto deserializedContent = JsonConvert.DeserializeObject<TEntityDto>(await responseResult.Content.ReadAsStringAsync());
                        TEntity currentReturnobject = _mapper.Map<TEntityDto, TEntity>(deserializedContent);
                    }
                }
                return true;
            }
            catch (Exception apiCommunicationError)
            {
                _applicationLogTools.LogError(apiCommunicationError, new Dictionary<string, dynamic> { { "MethodName", "ApiPostAsync(List<TEntity> currentObjectCollection, string subPathUri = null)" }, { "ClassName", "ApiRepository " + typeof(TEntity).Name } });
            }

            return false;
        }

    }
}
