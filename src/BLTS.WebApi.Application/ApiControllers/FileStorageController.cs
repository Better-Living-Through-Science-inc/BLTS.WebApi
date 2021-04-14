using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.FileStorages;
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

namespace BLTS.WebApi.ApiControllers
{
    /// <summary>
    /// API access to file storage using permission based access
    /// todo: add per file permission based access vs only login access
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FileStorageController : ControllerBase
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly FileStorageManager _fileStorageManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="applicationLogTools"></param>
        /// <param name="fileStorageManager"></param>
        /// <param name="mapper"></param>
        public FileStorageController(IApplicationLogTools applicationLogTools
                                   , FileStorageManager fileStorageManager
                                   , IMapper mapper)
        {
            _applicationLogTools = applicationLogTools;
            _fileStorageManager = fileStorageManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get file by primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Stream>> Get(long primaryKey, CancellationToken cancellationToken)
        {
            try
            {
                FileStorage currentWorkingObject = await _fileStorageManager.GetAsync(primaryKey, cancellationToken);

                if (currentWorkingObject.Id != 0)
                {
                    StreamContent returnFileContent = new StreamContent(currentWorkingObject.FileData);
                    returnFileContent.Headers.ContentType = new MediaTypeHeaderValue(currentWorkingObject.ContentType);
                    returnFileContent.Headers.ContentLength = currentWorkingObject.FileData.Length;

                    return Ok(await returnFileContent.ReadAsStreamAsync(cancellationToken));
                }
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", "WebApi.FileStorageController" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="fileToStore"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FileStorageDto>> Save(IFormFile fileToStore)
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
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", "WebApi.FileStorageController" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }

            return _mapper.Map<FileStorage, FileStorageDto>(currentWorkingObject);
        }

        /// <summary>
        /// Delete file by primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(long primaryKey)
        {
            try
            {
                FileStorage currentDeletingObject = new FileStorage() { Id = primaryKey };

                return await _fileStorageManager.DeleteAsync(currentDeletingObject);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", "WebApi.FileStorageController" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

    }
}
