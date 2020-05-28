using System.Threading.Tasks;
using Abp.Application.Services;
using BLTS.WebApi.Sessions.Dto;

namespace BLTS.WebApi.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
