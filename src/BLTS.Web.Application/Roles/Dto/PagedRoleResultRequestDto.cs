using Abp.Application.Services.Dto;

namespace BLTS.Web.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

