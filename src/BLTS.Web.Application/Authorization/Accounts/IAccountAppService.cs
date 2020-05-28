using System.Threading.Tasks;
using Abp.Application.Services;
using BLTS.Web.Authorization.Accounts.Dto;

namespace BLTS.Web.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
