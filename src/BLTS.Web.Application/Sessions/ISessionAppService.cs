using System.Threading.Tasks;
using Abp.Application.Services;
using BLTS.Web.Sessions.Dto;

namespace BLTS.Web.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
