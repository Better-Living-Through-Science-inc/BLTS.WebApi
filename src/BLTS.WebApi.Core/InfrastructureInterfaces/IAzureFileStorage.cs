using BLTS.WebApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BLTS.WebApi.InfrastructureInterfaces
{
    public interface IAzureFileStorage
    {
        bool Delete(FileStorage entity);
        Task<bool> DeleteAsync(FileStorage entity);
        FileStorage Get(long id);
        Task<FileStorage> GetAsync(long id, CancellationToken cancellationToken);
        FileStorage Save(FileStorage entity);
        Task<FileStorage> SaveAsync(FileStorage entity);
    }
}
