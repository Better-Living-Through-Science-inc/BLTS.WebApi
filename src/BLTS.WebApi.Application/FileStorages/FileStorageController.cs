using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace BLTS.WebApi.FileStorages
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FileStorageController : ControllerBase
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly FileStorageManager _fileStorageManager;
        private readonly IMapper _mapper;

        public FileStorageController(IApplicationLogTools applicationLogTools
                                   , FileStorageManager fileStorageManager
                                   , IMapper mapper)
        {
            _applicationLogTools = applicationLogTools;
            _fileStorageManager = fileStorageManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Stream> Get(DtoEntity<long> input, CancellationToken cancellationToken)
        {
            try
            {
                FileStorage currentWorkingObject = await _fileStorageManager.GetAsync(input.Id, cancellationToken);

                StreamContent returnFileContent = new StreamContent(currentWorkingObject.FileData);
                returnFileContent.Headers.ContentType = new MediaTypeHeaderValue(currentWorkingObject.ContentType);
                returnFileContent.Headers.ContentLength = currentWorkingObject.FileData.Length;

                return await returnFileContent.ReadAsStreamAsync();
            }
            catch (Exception fileStorageError)
            {
                _applicationLogTools.LogError(fileStorageError, new Dictionary<string, dynamic> { { "ClassName", "WebApi.FileStorages" } });
                return null;
            }
        }

        [HttpPost]
        public async Task<FileStorageDto> Save(IFormFile fileToStore)
        {
            FileStorage currentWorkingObject = new FileStorage();
            try
            {
                currentWorkingObject.FileData = fileToStore.OpenReadStream();
                currentWorkingObject.ContentType = fileToStore.ContentType;
                currentWorkingObject.FileName = fileToStore.FileName;
                currentWorkingObject.SizeKB = fileToStore.Length / 1024;

                await _fileStorageManager.SaveAsync(currentWorkingObject);
            }
            catch (Exception fileStorageError)
            {
                _applicationLogTools.LogError(fileStorageError, new Dictionary<string, dynamic> { { "ClassName", "WebApi.FileStorages" } });
                throw fileStorageError;
            }

            return _mapper.Map<FileStorage, FileStorageDto>(currentWorkingObject);
        }

        [HttpDelete]
        public async Task<bool> Delete(long primaryKey)
        {
            try
            {
                FileStorage currentDeletingObject = new FileStorage() { Id = primaryKey };

                return await _fileStorageManager.DeleteAsync(currentDeletingObject);
            }
            catch (Exception fileStorageError)
            {
                _applicationLogTools.LogError(fileStorageError, new Dictionary<string, dynamic> { { "ClassName", "WebApi.FileStorages" } });
                throw fileStorageError;
            }
        }

    }
}
