using Abp.Application.Services;
using BLTS.Web.MultiTenancy.Dto;

namespace BLTS.Web.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

