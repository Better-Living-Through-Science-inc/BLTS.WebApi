using BLTS.WebApi.InfrastructureInterfaces;
using BLTS.WebApi.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BLTS.WebApi.FileStorages
{
    public class FileStorageManager
    {
        private readonly IAzureFileStorage _azureFileStorage;

        public FileStorageManager(IAzureFileStorage azureFileStorage)
        {
            _azureFileStorage = azureFileStorage;
        }

        public bool Delete(FileStorage entity)
        {
            return _azureFileStorage.Delete(entity);
        }

        public async Task<bool> DeleteAsync(FileStorage entity)
        {
            return await _azureFileStorage.DeleteAsync(entity);
        }

        public FileStorage Get(long id)
        {
            return _azureFileStorage.Get(id);
        }

        public async Task<FileStorage> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await _azureFileStorage.GetAsync(id, cancellationToken);
        }

        public FileStorage Save(FileStorage entity)
        {
            return _azureFileStorage.Save(entity);
        }

        public async Task<FileStorage> SaveAsync(FileStorage entity)
        {
            return await _azureFileStorage.SaveAsync(entity);
        }
    }
}
