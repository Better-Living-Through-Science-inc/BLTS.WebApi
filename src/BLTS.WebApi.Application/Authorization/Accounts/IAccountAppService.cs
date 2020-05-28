using System.Threading.Tasks;
using Abp.Application.Services;
using BLTS.WebApi.Authorization.Accounts.Dto;

namespace BLTS.WebApi.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
