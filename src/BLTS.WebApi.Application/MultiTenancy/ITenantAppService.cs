using Abp.Application.Services;
using BLTS.WebApi.MultiTenancy.Dto;

namespace BLTS.WebApi.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

