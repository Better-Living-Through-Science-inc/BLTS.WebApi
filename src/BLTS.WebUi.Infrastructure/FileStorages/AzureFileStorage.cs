using BLTS.WebApi.Configurations;
using BLTS.WebApi.InfrastructureInterfaces;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLTS.WebUi.Infrastructure.FileStorages
{
    public class AzureFileStorage : IAzureFileStorage
    {
        private ApplicationLogTools _applicationLogTools;
        private ConfigurationManager _configurationManager;
        private readonly IRepository<FileStorage, long> _repositoryFileStorage;

        public AzureFileStorage(ApplicationLogTools applicationLogTools
                              , ConfigurationManager configurationManager
                              , IRepository<FileStorage, long> repositoryFileStorage)
        {
            _applicationLogTools = applicationLogTools;
            _configurationManager = configurationManager;
            _repositoryFileStorage = repositoryFileStorage;
        }

        public bool Delete(FileStorage entity)
        {
            return DeleteAsync(entity).Result;
        }

        public async Task<bool> DeleteAsync(FileStorage entity)
        {
            try
            {
                FileStorage currentWorkingObject = _repositoryFileStorage.Get(entity.Id);

                CloudFileDirectory currentRootDirectory = OpenFileShareConnection();
                CloudFileDirectory currentSubdirectory = currentRootDirectory.GetDirectoryReference(currentWorkingObject.SubPath.Replace(_configurationManager.GetValue("CloudStorageShareName") + "/", ""));

                CloudFile currentCloudSmbFile = currentSubdirectory.GetFileReference(currentWorkingObject.FileName);

                await currentCloudSmbFile.DeleteAsync();
                await currentSubdirectory.DeleteAsync();
                _repositoryFileStorage.Delete(currentWorkingObject);
            }
            catch (Exception fileStorageError)
            {
                _applicationLogTools.LogError(fileStorageError, new Dictionary<string, dynamic> { { "ClassName", "Infrastructure.FileStorages" } });
                return false;
            }

            return true;
        }

        public FileStorage Get(long id)
        {
            return GetAsync(id, new CancellationToken()).Result;
        }

        public async Task<FileStorage> GetAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                FileStorage currentWorkingObject = _repositoryFileStorage.Get(id);

                CloudFileDirectory currentRootDirectory = OpenFileShareConnection();
                CloudFileDirectory currentSubdirectory = currentRootDirectory.GetDirectoryReference(currentWorkingObject.SubPath.Replace(_configurationManager.GetValue("CloudStorageShareName") + "/", ""));
                CloudFile currentCloudSmbFile = currentSubdirectory.GetFileReference(currentWorkingObject.FileName);

                StreamContent returnFileContent = new StreamContent(await currentCloudSmbFile.OpenReadAsync(cancellationToken));
                returnFileContent.Headers.ContentType = new MediaTypeHeaderValue(currentWorkingObject.ContentType);
                returnFileContent.Headers.ContentLength = currentCloudSmbFile.Properties.Length;

                currentWorkingObject.FileData = await returnFileContent.ReadAsStreamAsync();
                return currentWorkingObject;
            }
            catch (Exception fileStorageError)
            {
                _applicationLogTools.LogError(fileStorageError, new Dictionary<string, dynamic> { { "ClassName", "Infrastructure.FileStorages" } });
                throw fileStorageError;
            }
        }

        public FileStorage Save(FileStorage entity)
        {
            return SaveAsync(entity).Result;
        }

        public async Task<FileStorage> SaveAsync(FileStorage entity)
        {
            try
            {
                CloudFileDirectory currentRootDirectory = OpenFileShareConnection();
                CloudFileDirectory currentSubdirectory = currentRootDirectory.GetDirectoryReference(Guid.NewGuid().ToString());
                await currentSubdirectory.CreateIfNotExistsAsync();

                CloudFile currentCloudSmbFile = currentSubdirectory.GetFileReference(entity.FileName);

                await currentCloudSmbFile.UploadFromStreamAsync(entity.FileData);

                entity.RootPath = currentRootDirectory.Uri.AbsoluteUri.Replace(currentRootDirectory.Uri.LocalPath, "");
                entity.SubPath = currentSubdirectory.Uri.AbsolutePath.Trim('/');

                _repositoryFileStorage.Save(entity);
            }
            catch (Exception fileStorageError)
            {
                _applicationLogTools.LogError(fileStorageError, new Dictionary<string, dynamic> { { "ClassName", "Infrastructure.FileStorages" } });
                throw fileStorageError;
            }

            return entity;
        }

        private CloudFileDirectory OpenFileShareConnection()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configurationManager.GetConnectionString("CloudStorageConnection"));
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare share = fileClient.GetShareReference(_configurationManager.GetValue("CloudStorageShareName"));

            return share.GetRootDirectoryReference();
        }
    }
}
