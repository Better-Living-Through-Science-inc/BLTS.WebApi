using Abp.Application.Services.Dto;

namespace BLTS.WebApi.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

